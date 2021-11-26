using PromotionEngine.Interface;
using PromotionEngine.Interface.DataObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Library.PromotionComp
{
    public abstract class Promotion : IPromotion
    {
        public IPromotionDetails PromotionDetails { get; set; }

        public abstract double GetValueAfterApplyingPromotion(IList<IOrder> orders);

        public string GetCurrentPromotionText()
        {
            StringBuilder promotionText = new StringBuilder();
            promotionText.Append(string.Join(", ", PromotionDetails.ProductList.Select(p => $"{p.Value} {p.Key}")));
            promotionText.Append($" For {PromotionDetails.PromotionValue}");

            return promotionText.ToString();
        }
    }
}
