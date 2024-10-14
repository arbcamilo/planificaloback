using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planificalo.Backend.Repositories.Interfaces
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<ActionResponse<IEnumerable<Event>>> GetAllAsync();
    }
}