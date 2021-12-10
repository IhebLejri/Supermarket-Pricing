namespace Business.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        
    }
}
