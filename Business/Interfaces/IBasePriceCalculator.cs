using Business.Entities;

namespace Business.Interfaces
{
    public interface IBasePriceCalculator
    {
        public decimal GetPrice(IOrder order);
    }
}
