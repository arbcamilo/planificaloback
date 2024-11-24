using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductType { get; set; }

        [MaxLength(500, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public List<ProductProvider>? ProductProvider { get; set; }

        public List<ProductQuote>? ProductQuote { get; set; }
    }
}