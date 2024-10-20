using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.DTOs
{
    public class ChangePasswordDTO
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} must be a valid email address.")]
        public string Email { get; set; }

        [Display(Name = "Current Password")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} must have between {2} and {1} characters.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}