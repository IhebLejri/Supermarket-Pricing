using System.Collections.Generic;

namespace Business.Entities
{
    public class Cart
    {
        public IEnumerable<Order> Orders { get; set; }

        public decimal GetTotal()
        {
            decimal total = 0;
            foreach(Order o in Orders)
            {
                total += o.GetPrice();
            }
            return total;
        }
    }
}
