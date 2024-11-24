using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class ProductEvent
    {
        public int ProviderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int EventId { get; set; }
    }
}