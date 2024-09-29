using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [MaxLength(500, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Description { get; set; }

        public List<ServiceProvider>? ServiceProviders { get; set; }

        public List<ServiceQuote>? ServiceQuotes { get; set; }
    }
}