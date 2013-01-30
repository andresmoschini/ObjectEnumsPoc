using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectEnum
{
    public sealed class ProductType : ObjectEnum<ProductType>
    {
        public static ProductType All = new ProductType("Red", 0);
        public static ProductType Processor = new ProductType("White", 1);
        public static ProductType GraphicCard = new ProductType("Black", 2);
        public static ProductType Notebook = new ProductType("Blue", 3);
        public static ProductType Desktop = new ProductType("Orange", 4);
        public static ProductType Motherboard = new ProductType("Brown", 7);

        //TODO: do it implicitly
        static ProductType()
        {
            AutoName();
        }

        public readonly string Color;

        private ProductType(string color, Nullable<int> ordinal = null)
            : base(ordinal)
        {
            Color = color;
        }
    }
}
