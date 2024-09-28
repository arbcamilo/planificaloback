using System.Collections.Generic;

namespace Planificalo.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

        public List<ProductProvider> ProductProvider { get; set; }

        public List<ProductQuote> ProductQuote { get; set; }
    }
}