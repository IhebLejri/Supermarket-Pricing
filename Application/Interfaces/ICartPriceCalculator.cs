using Business.Entities;

namespace Application.Interfaces
{
    public interface ICartPriceCalculator
    {
        public decimal Calculate(Cart cart);
    }
}
