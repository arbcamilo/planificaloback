namespace Planificalo.Shared.Entities
{
    public class ProductQuote
    {
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}