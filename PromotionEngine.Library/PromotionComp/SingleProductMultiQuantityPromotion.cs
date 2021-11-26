using PromotionEngine.Interface.DataObjects;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Library.PromotionComp
{
    /// <summary>
    /// Promotion for single product with multiple quantities
    /// E.g. 3 A's for 130 where unit price for 1 A is 50
    /// </summary>
    public class SingleProductMultiQuantityPromotion : Promotion
    {
        public SingleProductMultiQuantityPromotion(IPromotionDetails promotionDetails)
        {
            PromotionDetails = promotionDetails;
        }

        public override double GetValueAfterApplyingPromotion(IList<IOrder> orders)
        {
            if(PromotionDetails?.ProductList == null || !PromotionDetails.ProductList.Any() ||
                orders == null || !orders.Any())
            {
                return 0;
            }

            var promotionalProduct = PromotionDetails.ProductList.FirstOrDefault();
            if(promotionalProduct.Key != null)
            {
                //Filter all the products that qualify for this promotion
                var filtered = orders.FirstOrDefault(order => Equals(order.Product.SkuId, promotionalProduct.Key));
                if(filtered != null)
                {
                    //Remove qualified orders from orders list
                    orders.Remove(filtered);

                    var discountedQty = filtered.Quantity / promotionalProduct.Value;
                    var remainingQty = filtered.Quantity % promotionalProduct.Value;

                    return discountedQty * PromotionDetails.PromotionValue + remainingQty * filtered.Product.UnitPrice;
                }
            }

            return 0;
        }
    }
}
