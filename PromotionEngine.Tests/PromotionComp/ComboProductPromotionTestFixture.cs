using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Interface.DataObjects;
using PromotionEngine.Library.DataObjects;
using PromotionEngine.Library.PromotionComp;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Tests.PromotionComp
{
    [TestClass]
    public class ComboProductPromotionTestFixture
    {
        [TestMethod]
        public void Should_Return_Zero_When_PromotionDetails_Are_Null_Or_Empty()
        {
            //Arrange
            var obj = new ComboProductPromotion(null);
            var order = new List<IOrder> { new Order { Product = new Product { SkuId = "A", UnitPrice = 50 }, Quantity = 3 } };

            //Act
            var promoValue = obj.GetValueAfterApplyingPromotion(order);

            //Assert
            Assert.AreEqual(0, promoValue);

            obj = new ComboProductPromotion(new PromotionDetails());
            
            //Act
            promoValue = obj.GetValueAfterApplyingPromotion(order);

            //Assert
            Assert.AreEqual(0, promoValue);
        }

        [TestMethod]
        public void Should_Return_Zero_When_Orders_Are_Null_Or_Empty()
        {
            //Arrange
            var obj = new ComboProductPromotion(new PromotionDetails());

            //Act
            var promoValue = obj.GetValueAfterApplyingPromotion(null);

            //Assert
            Assert.AreEqual(0, promoValue);

            //Act
            promoValue = obj.GetValueAfterApplyingPromotion(new List<IOrder>());

            //Assert
            Assert.AreEqual(0, promoValue);
        }

        [TestMethod]
        public void Should_Return_PromotionValue()
        {
            //Arrange
            var obj = new ComboProductPromotion(new PromotionDetails
            {
                PromotionValue = 30,
                ProductList = new Dictionary<string, int> 
                { 
                    { "C", 1 },
                    { "D", 1 }
                }
            });
            var order = new List<IOrder> 
            { 
                new Order { Product = new Product { SkuId = "C", UnitPrice = 20 }, Quantity = 1 },
                new Order { Product = new Product { SkuId = "D", UnitPrice = 20 }, Quantity = 1 }
            };

            //Act
            var promoValue = obj.GetValueAfterApplyingPromotion(order);

            //Assert
            Assert.AreEqual(30, promoValue);
        }

        [TestMethod]
        public void Should_Calculate_PromotionValue_With_Other_Regular_Quantities()
        {
            //Arrange
            var obj = new ComboProductPromotion(new PromotionDetails
            {
                PromotionValue = 30,
                ProductList = new Dictionary<string, int>
                {
                    { "C", 1 },
                    { "D", 1 }
                }
            });
            var order = new List<IOrder>
            {
                new Order { Product = new Product { SkuId = "C", UnitPrice = 20 }, Quantity = 2 },
                new Order { Product = new Product { SkuId = "D", UnitPrice = 20 }, Quantity = 1 }
            };

            //Act
            var promoValue = obj.GetValueAfterApplyingPromotion(order);

            //Assert
            Assert.AreEqual(50, promoValue);
        }

        [TestMethod]
        public void Should_Display_PromotionText()
        {
            //Arrange
            var obj = new ComboProductPromotion(new PromotionDetails
            {
                PromotionValue = 30,
                ProductList = new Dictionary<string, int>
                {
                    { "C", 1 },
                    { "D", 1 }
                }
            });

            //Act
            var promoValue = obj.GetCurrentPromotionText();

            //Assert
            Assert.AreEqual("1 C, 1 D For 30", promoValue);
        }
    }
}
