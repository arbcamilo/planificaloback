using Planificalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planificalo.Shared.DTOs
{
    public class UserUpdateDTO : User
    {
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; } = null;

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; } = null;

        public string Language { get; set; } = null;
    }
}