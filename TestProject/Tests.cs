using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
	using ProductType = global::ClassicEnum.ProductType;
	using Util = global::ClassicEnum.Util;

    [TestClass()]
    public class ClassicEnum_Tests
    {
        [TestMethod()]
        public void ClassicEnum_GetAllValuesTest()
        {
            var target = new Util();
            ISet<ProductType> expected = new HashSet<ProductType>()
            {
                ProductType.All,
                ProductType.Processor,
                ProductType.GraphicCard,
                ProductType.Notebook,
                ProductType.Desktop,
                ProductType.Motherboard
            };
            ISet<ProductType> actual;
            actual = target.GetAllValues();
            Assert.IsTrue(expected.SetEquals(actual));
        }

        [TestMethod()]
        public void ClassicEnum_EqualsTest()
        {
            var processor1 = ProductType.Processor;
            var processor2 = ProductType.Processor;

            Assert.IsTrue(processor1 == processor2);
        }

        [TestMethod()]
        public void ClassicEnum_IsNotEqualTest()
        {
            var processor = ProductType.Processor;
            var motherboard = ProductType.Motherboard;

            Assert.IsFalse(processor == motherboard);
        }

        [TestMethod()]
        //Only works with Classic
        public void ClassicEnum_DefaultIsAllTest()
        {
            ProductType defaultValue = default(ProductType);
            Assert.AreEqual(ProductType.All, defaultValue);
        }

        [TestMethod()]
        //Only works with ObjectEnum
        public void ClassicEnum_DefaultEqualsNullTest()
        {
            ProductType defaultValue = default(ProductType);
            Assert.IsTrue(defaultValue == null);
        }

        [TestMethod()]
        public void ClassicEnum_ValidParseTest()
        {
            var target = new Util();
            var expected = ProductType.GraphicCard;
            
			var actual = target.Parse("GraphicCard");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ClassicEnum_ValidParseNameSpacesTest()
        {
            var target = new Util();
            var expected = ProductType.GraphicCard;
            
			var actual = target.Parse("   GraphicCard   ");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ClassicEnum_InvalidParseCaseInsensitiveTest()
        {
            var target = new Util();
            var expected = ProductType.GraphicCard;
            
			var actual = target.Parse("graphiccard");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ClassicEnum_ValidParseCaseInsensitiveTest()
        {
            var target = new Util();
            var expected = ProductType.GraphicCard;
            
            var actual = target.Parse("graphiccard", true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClassicEnum_InvalidParseNullTest()
        {
            var target = new Util();
            
            var actual = target.Parse(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ClassicEnum_InvalidParseEmptyTest()
        {
            var target = new Util();
            
			var actual = target.Parse("");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ClassicEnum_InvalidParseSpacesTest()
        {
            var target = new Util();
            
			var actual = target.Parse("    ");
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ClassicEnum_InvalidParseNameUnexistingNameTest()
        {
            var target = new Util();
            
			var actual = target.Parse("UnexistingName");
        }
    }
}
namespace TestProject
{
	using ProductType = global::ObjectEnum.ProductType;
	using Util = global::ObjectEnum.Util;

    [TestClass()]
    public class ObjectEnum_Tests
    {
        [TestMethod()]
        public void ObjectEnum_GetAllValuesTest()
        {
            var target = new Util();
            ISet<ProductType> expected = new HashSet<ProductType>()
            {
                ProductType.All,
                ProductType.Processor,
                ProductType.GraphicCard,
                ProductType.Notebook,
                ProductType.Desktop,
                ProductType.Motherboard
            };
            ISet<ProductType> actual;
            actual = target.GetAllValues();
            Assert.IsTrue(expected.SetEquals(actual));
        }

        [TestMethod()]
        public void ObjectEnum_EqualsTest()
        {
            var processor1 = ProductType.Processor;
            var processor2 = ProductType.Processor;

            Assert.IsTrue(processor1 == processor2);
        }

        [TestMethod()]
        public void ObjectEnum_IsNotEqualTest()
        {
            var processor = ProductType.Processor;
            var motherboard = ProductType.Motherboard;

            Assert.IsFalse(processor == motherboard);
        }

        [TestMethod()]
        //Only works with Classic
        public void ObjectEnum_DefaultIsAllTest()
        {
            ProductType defaultValue = default(ProductType);
            Assert.AreEqual(ProductType.All, defaultValue);
        }

        [TestMethod()]
        //Only works with ObjectEnum
        public void ObjectEnum_DefaultEqualsNullTest()
        {
            ProductType defaultValue = default(ProductType);
            Assert.IsTrue(defaultValue == null);
        }

        [TestMethod()]
        public void ObjectEnum_ValidParseTest()
        {
            var target = new Util();
            var expected = ProductType.GraphicCard;
            
			var actual = target.Parse("GraphicCard");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ObjectEnum_ValidParseNameSpacesTest()
        {
            var target = new Util();
            var expected = ProductType.GraphicCard;
            
			var actual = target.Parse("   GraphicCard   ");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ObjectEnum_InvalidParseCaseInsensitiveTest()
        {
            var target = new Util();
            var expected = ProductType.GraphicCard;
            
			var actual = target.Parse("graphiccard");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ObjectEnum_ValidParseCaseInsensitiveTest()
        {
            var target = new Util();
            var expected = ProductType.GraphicCard;
            
            var actual = target.Parse("graphiccard", true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObjectEnum_InvalidParseNullTest()
        {
            var target = new Util();
            
            var actual = target.Parse(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ObjectEnum_InvalidParseEmptyTest()
        {
            var target = new Util();
            
			var actual = target.Parse("");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ObjectEnum_InvalidParseSpacesTest()
        {
            var target = new Util();
            
			var actual = target.Parse("    ");
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ObjectEnum_InvalidParseNameUnexistingNameTest()
        {
            var target = new Util();
            
			var actual = target.Parse("UnexistingName");
        }
    }
}
