using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planificalo.Backend.Repositories.Interfaces
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        new Task<ActionResponse<IEnumerable<Event>>> GetAllAsync();

        Task<ActionResponse<Event>> GetByIdAsync(int id);
    }
}