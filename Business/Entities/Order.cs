using Business.Interfaces;

namespace Business.Entities
{
    public class Order : IOrder
    {
        private readonly IBasePriceCalculator _calculator;
        public Order(IBasePriceCalculator calculator)
        {
            _calculator = calculator;
        }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public decimal GetPrice()
        {
            return _calculator.GetPrice(this);
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public decimal GetUnitPrice()
        {
            return Product.UnitPrice;
        }
    }
}
