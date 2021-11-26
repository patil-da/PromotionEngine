using PromotionEngine.Interface.DataObjects;

namespace PromotionEngine.Library.DataObjects
{
    public class Order : IOrder
    {
        public IProduct Product { get; set; }

        public int Quantity { get; set; }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Product.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
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

            return Equals((Order)obj);
        }

        protected bool Equals(Order other)
        {
            return Product.Equals(other.Product) && Quantity == other.Quantity;
        }
    }
}
