using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planificalo.Shared.DTOs
{
    public class LoginDTO
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} must be a valid email address.")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [MinLength(6, ErrorMessage = "The field {0} must have at least {1} characters.")]
        public string Password { get; set; }
    }
}