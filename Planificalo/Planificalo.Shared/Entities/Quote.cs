using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Quote
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int Quantity { get; set; }
        public decimal Total { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public DateTime QuoteDate { get; set; }

        public DateTime? ResponseDate { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string QuoteStatus { get; set; }

        [MaxLength(500, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Notes { get; set; }

        // Relationship with ProductQuote
        public List<ProductQuote>? ProductQuotes { get; set; }

        // Relationship with ServiceQuote
        public List<ServiceQuote>? ServiceQuotes { get; set; }
    }
}