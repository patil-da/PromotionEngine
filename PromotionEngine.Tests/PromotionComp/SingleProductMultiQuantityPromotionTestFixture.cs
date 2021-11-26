using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Interface.DataObjects;
using PromotionEngine.Library.DataObjects;
using PromotionEngine.Library.PromotionComp;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Tests.PromotionComp
{
    [TestClass]
    public class SingleProductMultiQuantityPromotionTestFixture
    {
        [TestMethod]
        public void Should_Return_Zero_When_PromotionDetails_Are_Null_Or_Empty()
        {
            //Arrange
            var obj = new SingleProductMultiQuantityPromotion(null);
            var order = new List<IOrder> { new Order { Product = new Product { SkuId = "A", UnitPrice = 50 }, Quantity = 3 } };

            //Act
            var promoValue = obj.GetValueAfterApplyingPromotion(order);

            //Assert
            Assert.AreEqual(0, promoValue);

            obj = new SingleProductMultiQuantityPromotion(new PromotionDetails());
            
            //Act
            promoValue = obj.GetValueAfterApplyingPromotion(order);

            //Assert
            Assert.AreEqual(0, promoValue);
        }

        [TestMethod]
        public void Should_Return_Zero_When_Orders_Are_Null_Or_Empty()
        {
            //Arrange
            var obj = new SingleProductMultiQuantityPromotion(new PromotionDetails());

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
            var obj = new SingleProductMultiQuantityPromotion(new PromotionDetails
            {
                PromotionValue = 130,
                ProductList = new Dictionary<string, int> { { "A", 3 } }
            });
            var order = new List<IOrder> { new Order { Product = new Product { SkuId = "A", UnitPrice = 50 }, Quantity = 3 } };

            //Act
            var promoValue = obj.GetValueAfterApplyingPromotion(order);

            //Assert
            Assert.AreEqual(130, promoValue);
        }

        [TestMethod]
        public void Should_Calculate_PromotionValue_With_Other_Regular_Quantities()
        {
            //Arrange
            var obj = new SingleProductMultiQuantityPromotion(new PromotionDetails
            {
                PromotionValue = 130,
                ProductList = new Dictionary<string, int> { { "A", 3 } }
            });
            var order = new List<IOrder> 
            { 
                new Order { Product = new Product { SkuId = "A", UnitPrice = 50 }, Quantity = 5 } 
            };

            //Act
            var promoValue = obj.GetValueAfterApplyingPromotion(order);

            //Assert
            Assert.AreEqual(230, promoValue);
        }

        [TestMethod]
        public void Should_Display_PromotionText()
        {
            //Arrange
            var obj = new SingleProductMultiQuantityPromotion(new PromotionDetails
            {
                PromotionValue = 130,
                ProductList = new Dictionary<string, int> { { "A", 3 } }
            });
            
            //Act
            var promoValue = obj.GetCurrentPromotionText();

            //Assert
            Assert.AreEqual("3 A For 130", promoValue);
        }
    }
}
