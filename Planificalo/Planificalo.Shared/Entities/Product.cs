using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        [MaxLength(500, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Description { get; set; }

        public List<ProductProvider>? ProductProvider { get; set; }

        public List<ProductQuote>? ProductQuote { get; set; }
    }
}