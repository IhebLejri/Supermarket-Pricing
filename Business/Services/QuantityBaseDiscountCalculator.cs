using Business.Interfaces;

namespace Business.Services
{
    public class QuantityBaseDiscountCalculator : BasePriceCalculator
    {
        public override decimal GetPrice(IOrder order)
        {
            if(order.GetQuantity() >= 5 && order.GetQuantity() < 10)
            {
                return base.GetPrice(order) * 0.9M;
            }
            else if(order.GetQuantity() >= 10)
            {
                return base.GetPrice(order) * 0.8M;
            }
            else
            {
                return base.GetPrice(order);
            }
                
        }
    }
}
