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

        // Relaci�n con ProveedorProducto
        public List<ProveedorProducto> ProveedorProductos { get; set; }

        // Relaci�n con CotizacionProducto
        public List<CotizacionProducto> CotizacionProductos { get; set; }
    }
}