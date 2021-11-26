
namespace PromotionEngine.Interface.DataObjects
{
    public interface IOrder
    {
        IProduct Product { get; set; }

        int Quantity { get; set; }
    }
}
