namespace Planificalo.Shared.Entities
{
    public class Desistimiento
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public bool Aprobado { get; set; }
    }
}