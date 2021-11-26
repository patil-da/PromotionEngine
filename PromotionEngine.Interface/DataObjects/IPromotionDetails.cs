using System.Collections.Generic;

namespace PromotionEngine.Interface.DataObjects
{
    public interface IPromotionDetails
    {
        Dictionary<string, int> ProductList { get; set; }

        double PromotionValue { get; set; }
    }
}
