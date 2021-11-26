using PromotionEngine.Interface.DataObjects;
using PromotionEngine.Library;
using PromotionEngine.Library.DataObjects;
using PromotionEngine.Library.PromotionComp;
using System;
using System.Collections.Generic;


namespace PromotionEngine.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<IOrder>
            {
                new Order { Product = new Product{ SkuId = "A", UnitPrice = 50 }, Quantity = 3 },
                new Order { Product = new Product{ SkuId = "B", UnitPrice = 30 }, Quantity = 2 },
                new Order { Product = new Product{ SkuId = "C", UnitPrice = 20 }, Quantity = 1 },
                new Order { Product = new Product{ SkuId = "D", UnitPrice = 20 }, Quantity = 1 }
            };

            var promotionEngine = new PromotionalEngine(new SeasonalPromotion());
            promotionEngine.ShowCurrentActivePromotions();

            Console.WriteLine($"Total value for your order is : {promotionEngine.GetOrderValue(orders)}");

            Console.ReadLine();
        }
    }
}
