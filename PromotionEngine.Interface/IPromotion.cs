using PromotionEngine.Interface.DataObjects;
using System.Collections.Generic;

namespace PromotionEngine.Interface
{
    public interface IPromotion
    {
        double GetValueAfterApplyingPromotion(IList<IOrder> orders);

        string GetCurrentPromotionText();
    }
}
