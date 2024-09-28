namespace Planificalo.Shared.Entities
{
    public class ServiceQuote
    {
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}