namespace Planificalo.Shared.Entities
{
    public class CotizacionServicio
    {
        public int CotizacionId { get; set; }
        public Cotizacion Cotizacion { get; set; }

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}