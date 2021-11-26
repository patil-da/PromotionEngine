using System.Collections.Generic;

namespace PromotionEngine.Interface
{
    public interface IPromotionBuilder
    {
        IList<IPromotion> GetActivePromotions();
    }
}
