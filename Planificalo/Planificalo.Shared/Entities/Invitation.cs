namespace Planificalo.Shared.Entities
{
    public class Invitation
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int GuestId { get; set; }
        public DateTime SendDate { get; set; }
        public bool InvitationStatus { get; set; }
    }
}