using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planificalo.Backend.UnitsOfWork.Interfaces
{
    public interface IEventsUnitOfWork : IGenericUnitOfWork<Event>
    {
        Task<ActionResponse<IEnumerable<Event>>> GetAllAsync();
    }
}