using Microsoft.AspNetCore.Identity;
using Planificalo.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planificalo.Shared.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string FirstName { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string LastName { get; set; }

        public string DocumentType { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        [Required(ErrorMessage = "The field {0} is required")]
        public string DocumentNumber { get; set; }

        public UserType? UserType { get; set; }
        public string? Photo { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string? UserStatus { get; set; }

        public DateOnly BirthDate { get; set; }
        public DateOnly? AccountCreationDate { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}