using System.Collections.Generic;

namespace Business.Entities
{
    public class Cart
    {
        public IEnumerable<Order> Orders { get; set; }

        public decimal GetTotal()
        {
            return 0;
        }
    }
}
