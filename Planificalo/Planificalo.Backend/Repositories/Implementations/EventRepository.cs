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

        public async Task<ActionResponse<Event>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dataContext.Events
                    .Include(e => e.ProductEvent)
                    .Include(e => e.ServiceEvent)
                    .FirstOrDefaultAsync(e => e.Id == id);

                return new ActionResponse<Event>
                {
                    Success = entity != null,
                    Entity = entity
                };
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<Event>
                {
                    Success = false,
                    CodError = "DB001",
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<Event>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                };
            }
        }

        public new async Task<ActionResponse<IEnumerable<Event>>> GetAllAsync()
        {
            try
            {
                var entities = await _dataContext.Events
                    .Include(e => e.ProductEvent)
                    .Include(e => e.ServiceEvent)
                    .ToListAsync();

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