namespace Exercise.Models
{
    public class Trolley
    {
        public Product[] Products { get; set; }
        public Special[] Specials { get; set; }
        public ProductQuantity Quantities { get; set; }
    }

    public class Special
    {
        public ProductQuantity[] Quantities { get; set; }
        public decimal Total { get; set; }
    }


    public class ProductQuantity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}