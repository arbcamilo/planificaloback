using System;
using System.Collections.Generic;

namespace Planificalo.Shared.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string Location { get; set; }
        public int EventTypeId { get; set; }
        public string? Image { get; set; }

        // Relationship with Quote
        public List<Quote> Quotes { get; set; }
    }
}