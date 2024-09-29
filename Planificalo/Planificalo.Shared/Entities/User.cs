using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(40, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public long IdentityDocument { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(15, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Phone { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string UserStatus { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public DateOnly AccountCreationDate { get; set; }
    }
}