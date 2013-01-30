using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ObjectEnum
{
    public abstract class ObjectEnum<TEnum>
        where TEnum : ObjectEnum<TEnum>
    {
        public int Ordinal { get; private set; }
        private static readonly Dictionary<int, TEnum> byOrdinal = new Dictionary<int, TEnum>();

        public string Name { get; private set; }
        private static readonly Dictionary<string, TEnum> byNameCaseSensitive = new Dictionary<string, TEnum>(StringComparer.InvariantCulture);
        private static readonly Dictionary<string, TEnum> byNameCaseInsensitive = new Dictionary<string, TEnum>(StringComparer.InvariantCultureIgnoreCase);

        protected static void AutoName()
        {
            //TODO: call it implicitly
            var instanceMembers = typeof(TEnum)
                .GetMembers(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField)
                .OfType<FieldInfo>()
                .Where(x => x.FieldType == typeof(TEnum));

            foreach (var enumMember in instanceMembers)
            {
                var enumValue = (TEnum)enumMember.GetValue(null);

                if (enumValue != null)
                    enumValue.Name = enumMember.Name;

                byNameCaseSensitive.Add(enumValue.Name, enumValue);
                byNameCaseInsensitive.Add(enumValue.Name, enumValue);
            }
        }

        protected ObjectEnum(int? ordinal = null)
        {
            if (!ordinal.HasValue)
            {
                ordinal = byOrdinal.Any()
                    ? byOrdinal.Keys.Max() + 1
                    : 0;
            }

            Ordinal = ordinal.Value;
            byOrdinal.Add(this.Ordinal, (TEnum)this);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public static ISet<TEnum> GetAllValues()
        {
            return new HashSet<TEnum>(byOrdinal.Values.Cast<TEnum>());
        }

        public static TEnum Parse(string value, bool ignoreCase = false)
        {
            if (value == null)
                throw new ArgumentNullException("value", "parameter value is null");

            value = value.Trim();

            if (value == string.Empty)
                throw new ArgumentException("value", "parameter value is null or white space");

            TEnum result;

            var dict = ignoreCase ? byNameCaseInsensitive : byNameCaseSensitive;

            if (!dict.TryGetValue(value, out result))
                throw new ArgumentException("value", "value is not one of the named constants");

            return result;
        }

        public static explicit operator int(ObjectEnum<TEnum> x)
        {
            return x.Ordinal;
        }

        public static explicit operator ObjectEnum<TEnum>(int x)
        {
            TEnum enumInstance;
            if (!byOrdinal.TryGetValue(x, out enumInstance))
                throw new ArgumentException(
                    string.Format("Enum value {0} not found", x, "x"));
 
            return enumInstance;
        }
    }
}
