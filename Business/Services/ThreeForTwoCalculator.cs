using Business.Interfaces;

namespace Business.Services
{
    public class ThreeForTwoCalculator : BasePriceCalculator
    {
        public override decimal GetPrice(IOrder order)
        {
            return 0;

        }
    }
}
