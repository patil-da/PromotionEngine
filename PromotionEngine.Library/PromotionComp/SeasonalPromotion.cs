using PromotionEngine.Interface;
using PromotionEngine.Library.DataObjects;
using System.Collections.Generic;

namespace PromotionEngine.Library.PromotionComp
{
    public class SeasonalPromotion : IPromotionBuilder
    {
        public IList<IPromotion> GetActivePromotions()
        {
            //Here we can call backend api to populate promotions list
            return new List<IPromotion>
            {
                new ComboProductPromotion(new PromotionDetails
                {
                    PromotionValue = 30,
                    ProductList = new Dictionary<string, int>
                    {
                        { "C", 1 },
                        { "D", 1 },
                    }
                }),
                new SingleProductMultiQuantityPromotion(new PromotionDetails
                {
                    PromotionValue = 130,
                    ProductList = new Dictionary<string, int>{ { "A", 3 } }
                }),
                new SingleProductMultiQuantityPromotion(new PromotionDetails
                {
                    PromotionValue = 45,
                    ProductList= new Dictionary<string, int>{ { "B", 2 } }
                })
            };
        }
    }
}
