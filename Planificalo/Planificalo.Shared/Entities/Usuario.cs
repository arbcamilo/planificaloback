using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(40, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public Int64 DocumentoIdentidad { get; set; }

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Celular { get; set; }

        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public DateTime FechaCreacionCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public DateTime FechaNacimiento { get; set; }
    }
}