namespace Planificalo.Shared.Entities
{
    public class Revocation
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public bool Approved { get; set; }
    }
}