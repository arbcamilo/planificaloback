using System.Collections.Generic;

namespace Planificalo.Shared.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }
        public decimal Price { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }

        // Relationship with ServiceProvider
        public List<ServiceProvider> ServiceProviders { get; set; }

        // Relationship with ServiceQuote
        public List<ServiceQuote> ServiceQuotes { get; set; }
    }
}