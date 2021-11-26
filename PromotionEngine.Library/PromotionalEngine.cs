using PromotionEngine.Interface;
using PromotionEngine.Interface.DataObjects;
using PromotionEngine.Library.DataObjects;
using PromotionEngine.Library.PromotionComp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Library
{
    public class PromotionalEngine
    {
        public IList<IPromotion> ActivePromotions { get; set; }

        public PromotionalEngine(IPromotionBuilder promotionBuilder)
        {
            //Initialize it with current active promotions
            //This data for product and 
            if(promotionBuilder == null)
            {
                //Initialize empty list
                ActivePromotions = new List<IPromotion>();
                return;
            }
            ActivePromotions = promotionBuilder.GetActivePromotions();
        }

        public void ShowCurrentActivePromotions()
        {
            Console.WriteLine("********Current Active Promotions********");
            if (ActivePromotions == null)
            {
                return;
            }
            foreach (var promotion in ActivePromotions)
            {
                Console.WriteLine(promotion.GetCurrentPromotionText());
            }
        }

        public double GetOrderValue(IList<IOrder> orders)
        {
            if (orders == null || !orders.Any())
            {
                return 0;
            }

            double orderValue = 0;
            var orderToProcess = orders.ToList();

            try
            {
                foreach (var promotion in ActivePromotions)
                {
                    orderValue += promotion.GetValueAfterApplyingPromotion(orderToProcess);
                }

                foreach (var order in orderToProcess)
                {
                    orderValue += order.Quantity * order.Product.UnitPrice;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

            return orderValue;
        }
    }
}
