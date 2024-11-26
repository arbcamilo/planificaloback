namespace Planificalo.Shared.Entities
{
    public class ProductProvider
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}