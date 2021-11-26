using PromotionEngine.Interface.DataObjects;
using System.Collections.Generic;

namespace PromotionEngine.Library.DataObjects
{
    public class PromotionDetails : IPromotionDetails
    {
        public Dictionary<string, int> ProductList { get; set; }

        public double PromotionValue { get; set; }
    }
}
