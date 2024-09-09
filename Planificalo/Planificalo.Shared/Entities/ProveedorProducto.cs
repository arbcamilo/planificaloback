namespace Planificalo.Shared.Entities
{
    public class ProveedorProducto
    {
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}