using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Provider
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(200, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} must be a valid email.")]
        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(15, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string ContactPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        public bool IsNaturalPerson { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(20, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(20, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        public string DocumentType { get; set; } = string.Empty;

        [Required(ErrorMessage = "The field {0} is required.")]
        public long IdentityDocument { get; set; }

        // Relationship with Quote
        public List<Quote> Quotes { get; set; } = new List<Quote>();

        // Relationship with ServiceProvider
        public List<ServiceProvider> ServiceProviders { get; set; } = new List<ServiceProvider>();

        // Relationship with ProductProvider
        public List<ProductProvider> ProductProviders { get; set; } = new List<ProductProvider>();
    }
}