using System.Collections.Generic;

namespace Exercise.Models
{
    public class ShopperHistory
    {
        public string CustomerId { get; set; }
        public IList<Product> Products { get; set; }
    }
}