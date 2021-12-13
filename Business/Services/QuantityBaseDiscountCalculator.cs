using Business.Interfaces;

namespace Business.Services
{
    public class QuantityBaseDiscountCalculator : BasePriceCalculator
    {
        public override decimal GetPrice(IOrder order)
        {
            return 0;
                
        }
    }
}
