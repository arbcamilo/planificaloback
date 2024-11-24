namespace Planificalo.Shared.Entities
{
    public class ServiceProvider
    {
        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}