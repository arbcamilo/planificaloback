using Microsoft.AspNetCore.Identity;
using Planificalo.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(40, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public long IdentityDocument { get; set; }

        public UserType UserType { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";

        public string? Photo { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string UserStatus { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public DateOnly AccountCreationDate { get; set; }
    }
}