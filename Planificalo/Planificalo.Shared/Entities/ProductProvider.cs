namespace Planificalo.Shared.Entities
{
    public class ProductProvider
    {
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}