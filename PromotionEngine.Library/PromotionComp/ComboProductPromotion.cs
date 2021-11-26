using PromotionEngine.Interface.DataObjects;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Library.PromotionComp
{
    /// <summary>
    /// Promotion for multiple products with single/multiple quantities
    /// E.g. 1 C and 1 D for 30 Or 2 C's and 1 D for 45
    /// </summary>
    public class ComboProductPromotion : Promotion
    {
        public ComboProductPromotion(IPromotionDetails promotionDetails)
        {
            PromotionDetails = promotionDetails;
        }

        public override double GetValueAfterApplyingPromotion(IList<IOrder> orders)
        {
            if (PromotionDetails?.ProductList == null || !PromotionDetails.ProductList.Any() ||
                orders == null || !orders.Any())
            {
                return 0;
            }

            var promotionalProducts = PromotionDetails.ProductList;

            //convert orders to dictionary
            var orderDict = orders.ToDictionary(order => order.Product.SkuId, order => order);
            var lowestQty = -1;
            var filtered = new List<IOrder>();
            double totalValue = 0;

            //find lowest possible combination quantity for combined product promotion
            foreach (var promotionalProduct in promotionalProducts)
            {
                if(!orderDict.ContainsKey(promotionalProduct.Key))
                {
                    //Some products are not in the order list, so this order does not qualify for the promotion
                    //Keep the orders as it is and return zero
                    return 0;
                }

                var order = orderDict[promotionalProduct.Key];
                filtered.Add(order);
                var discQty = order.Quantity / promotionalProduct.Value;
                if(lowestQty == -1 || lowestQty > discQty)
                {
                    lowestQty = discQty;
                }
            }

            //Remove all the orders that qualify for this promotion
            foreach (var order in filtered)
            {
                orders.Remove(order);
            }

            //Deduct discounted quantities and calculate value for remaining quantities
            foreach (var promoProduct in promotionalProducts)
            {
                var order = orderDict[promoProduct.Key];
                var remainingQty = order.Quantity - (lowestQty * promoProduct.Value);

                totalValue += remainingQty * order.Product.UnitPrice;
            }

            //Add promotion value for combinations of products
            totalValue += lowestQty * PromotionDetails.PromotionValue;

            return totalValue;
        }
    }
}
