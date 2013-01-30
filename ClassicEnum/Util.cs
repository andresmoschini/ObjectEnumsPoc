using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassicEnum
{
    public class Util
    {
        public ISet<ProductType> GetAllValues()
        {
            return new HashSet<ProductType>(Enum.GetValues(typeof(ProductType)).Cast<ProductType>());
        }

        public ProductType Parse(string value, bool ignoreCase = false)
        {
            return (ProductType)Enum.Parse(typeof(ProductType), value, ignoreCase);
        }
    }
}
