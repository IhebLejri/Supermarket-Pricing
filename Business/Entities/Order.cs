using Business.Interfaces;

namespace Business.Entities
{
    public class Order : IOrder
    {
     
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public decimal GetPrice()
        {
            return 0;
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
