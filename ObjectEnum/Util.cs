using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectEnum
{
    public class Util
    {
        public ISet<ProductType> GetAllValues()
        {
            return ProductType.GetAllValues();
        }

        public ProductType Parse(string value, bool ignoreCase = false)
        {
            return ProductType.Parse(value, ignoreCase);
        }
    }
}
