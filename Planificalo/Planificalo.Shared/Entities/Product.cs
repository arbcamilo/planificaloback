using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductType { get; set; }
    }
}