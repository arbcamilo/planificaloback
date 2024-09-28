namespace Planificalo.Shared.Entities
{
    public class ServiceProvider
    {
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}