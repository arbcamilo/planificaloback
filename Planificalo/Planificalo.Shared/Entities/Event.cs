using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public int UserId { get; set; }
        public string Location { get; set; }
        public int EventTypeId { get; set; }
        public string IsPrivate { get; set; }
        public string EventStatus { get; set; }
        public string? ImageEvent { get; set; }

        [MaxLength(500, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public List<ProductEvent>? ProductEvent { get; set; }

        public List<ServiceEvent>? ServiceEvent { get; set; }
    }
}