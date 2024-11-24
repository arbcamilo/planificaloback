using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class ServiceEvent
    {
        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int EventId { get; set; }
    }
}