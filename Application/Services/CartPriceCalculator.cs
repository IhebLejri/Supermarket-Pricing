using Application.Interfaces;
using Business.Entities;

namespace Business.Services
{
    public class CartPriceCalculator : ICartPriceCalculator
    {
        public decimal Calculate(Cart cart)
        {
            return cart.GetTotal();
        }
    }
}
