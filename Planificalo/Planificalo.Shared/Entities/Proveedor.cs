using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Pais { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Departamento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un email válido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string TelefonoContacto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public bool EsPersonaNatural { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Estado { get; set; } = string.Empty;

        [Range(0, 5, ErrorMessage = "El campo {0} debe estar entre {1} y {2}.")]
        public double Calificacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long DocumentoIdentidad { get; set; }

        // Relación con Cotizacion
        public List<Cotizacion> Cotizaciones { get; set; } = new List<Cotizacion>();

        // Relación con ProveedorServicio
        public List<ProveedorServicio> ProveedorServicios { get; set; } = new List<ProveedorServicio>();

        // Relación con ProveedorProducto
        public List<ProveedorProducto> ProveedorProductos { get; set; } = new List<ProveedorProducto>();
    }
}