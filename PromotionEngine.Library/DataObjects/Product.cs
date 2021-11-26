using PromotionEngine.Interface.DataObjects;
using System;

namespace PromotionEngine.Library.DataObjects
{
    public class Product : IProduct
    {
        public string SkuId { get; set; }

        public double UnitPrice { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = SkuId.GetHashCode();
                hashCode = (hashCode * 397) ^ UnitPrice.GetHashCode();
                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Product)obj);
        }

        protected bool Equals(Product other)
        {
            return string.Equals(SkuId, other.SkuId, StringComparison.OrdinalIgnoreCase) && UnitPrice == other.UnitPrice;
        }
    }
}
