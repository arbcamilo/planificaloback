using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Guest
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string GuestStatus { get; set; }
    }
}