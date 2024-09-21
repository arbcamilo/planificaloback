namespace Planificalo.Shared.Entities
{
    public class Invitacion
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public int InvitadoId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public bool EstadoInvitacion { get; set; }
    }
}