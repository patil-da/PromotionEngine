using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Interface.DataObjects;
using PromotionEngine.Library;
using PromotionEngine.Library.DataObjects;
using PromotionEngine.Library.PromotionComp;
using System.Collections.Generic;

namespace PromotionEngine.Tests.PromotionComp
{
    [TestClass]
    public class PromotionalEngineTestFixture
    {
        [TestMethod]
        public void Should_Initialize_Empty_ActivePromotions()
        {
            //Arrange
            var obj = new PromotionalEngine(null);

            //Assert
            Assert.AreEqual(0, obj.ActivePromotions.Count);
        }

        [TestMethod]
        public void Should_Return_Zero_For_Null_Or_Empty_Orders()
        {
            //Arrange
            var obj = new PromotionalEngine(null);

            //Act
            var promoValue = obj.GetOrderValue(null);

            //Assert
            Assert.AreEqual(0, promoValue);

            //Act
            promoValue = obj.GetOrderValue(new List<IOrder>());

            //Assert
            Assert.AreEqual(0, promoValue);
        }

        [TestMethod]
        public void Should_Return_Regular_Value_For_Empty_Promotions()
        {
            //Arrange
            var obj = new PromotionalEngine(null);
            var orders = new List<IOrder> 
            { 
                new Order { Product = new Product { SkuId = "A", UnitPrice = 10 }, Quantity = 3 },
                new Order { Product = new Product { SkuId = "B", UnitPrice = 20 }, Quantity = 2 },
            };

            //Act
            var promoValue = obj.GetOrderValue(orders);

            //Assert
            Assert.AreEqual(70, promoValue);
        }

        [TestMethod]
        public void Should_Return_Promotion_With_Regular_Value_For_Applied_Promotions()
        {
            //Arrange
            var obj = new PromotionalEngine(new SeasonalPromotion());
            var orders = new List<IOrder>
            {
                new Order { Product = new Product { SkuId = "A", UnitPrice = 50 }, Quantity = 3 },
                new Order { Product = new Product { SkuId = "B", UnitPrice = 30 }, Quantity = 2 },
            };

            //Act
            var promoValue = obj.GetOrderValue(orders);

            //Assert
            Assert.AreEqual(175, promoValue);
        }
    }
}
