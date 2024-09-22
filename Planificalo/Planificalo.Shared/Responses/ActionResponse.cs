using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planificalo.Shared.Responses
{
    public class ActionResponse<T>
    {
        public bool Success { get; set; }
        public string? CodError { get; set; }
        public string? Message { get; set; }
        public T? Entity { get; set; }
    }
}