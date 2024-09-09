using System.Collections.Generic;

namespace Planificalo.Shared.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        // Relaci�n con ProveedorServicio
        public List<ProveedorServicio> ProveedorServicios { get; set; }

        // Relaci�n con CotizacionServicio
        public List<CotizacionServicio> CotizacionServicios { get; set; }
    }
}