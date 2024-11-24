using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }

        [MaxLength(500, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public List<ServiceProvider>? ServiceProviders { get; set; }

        public List<ServiceQuote>? ServiceQuotes { get; set; }
    }
}