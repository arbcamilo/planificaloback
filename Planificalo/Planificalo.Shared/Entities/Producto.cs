using System.Collections.Generic;

namespace Planificalo.Shared.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string TipoProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }

        // Relación con ProveedorProducto
        public List<ProveedorProducto> ProveedorProductos { get; set; }

        // Relación con CotizacionProducto
        public List<CotizacionProducto> CotizacionProductos { get; set; }
    }
}