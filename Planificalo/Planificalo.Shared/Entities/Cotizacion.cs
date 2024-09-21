using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Cotizacion
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaRespuesta { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener m�s de {1} caracteres")]
        public string Estado { get; set; }

        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener m�s de {1} caracteres")]
        public string Notas { get; set; }

        // Relaci�n con CotizacionProducto
        public List<CotizacionProducto> CotizacionProductos { get; set; }

        // Relaci�n con CotizacionServicio
        public List<CotizacionServicio> CotizacionServicios { get; set; }
    }
}