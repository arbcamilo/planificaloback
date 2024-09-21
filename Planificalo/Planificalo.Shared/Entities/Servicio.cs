using System.Collections.Generic;

namespace Planificalo.Shared.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        public string TipoServicio { get; set; }
        public decimal Precio { get; set; }
        public string cantidad { get; set; }
        public string Descripcion { get; set; }

        // Relaci�n con ProveedorServicio
        public List<ProveedorServicio> ProveedorServicios { get; set; }

        // Relaci�n con CotizacionServicio
        public List<CotizacionServicio> CotizacionServicios { get; set; }
    }
}