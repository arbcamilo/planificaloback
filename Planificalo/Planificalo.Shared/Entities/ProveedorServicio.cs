namespace Planificalo.Shared.Entities
{
    public class ProveedorServicio
    {
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}