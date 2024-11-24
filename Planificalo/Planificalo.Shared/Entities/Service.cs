using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planificalo.Shared.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }
    }
}