using Business.Interfaces;

namespace Business.Services
{
    public class BasePriceCalculator : IBasePriceCalculator
    {
        public virtual decimal GetPrice(IOrder order)
        {
            return order.GetUnitPrice() * order.GetQuantity();
        }
    }
}
