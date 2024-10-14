using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Backend.Repositories.Interfaces;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planificalo.Backend.Repositories.Implementations
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly DataContext _dataContext;

        public EventRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }

        public override async Task<ActionResponse<IEnumerable<Event>>> GetAllAsync()
        {
            try
            {
                var entities = await _dataContext.Events.ToListAsync();
                return new ActionResponse<IEnumerable<Event>>
                {
                    Success = true,
                    CodError = string.Empty,
                    Entity = entities
                };
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<IEnumerable<Event>>
                {
                    Success = false,
                    CodError = "DB001",
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<IEnumerable<Event>>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                };
            }
        }
    }
}