using Planificalo.Backend.Repositories.Interfaces;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planificalo.Backend.UnitsOfWork.Implementations
{
    public class EventsUnitOfWork : GenericUnitOfWork<Event>, IEventsUnitOfWork
    {
        private readonly IGenericRepository<Event> _genericRepository;
        private readonly IEventRepository _eventRepository;

        public EventsUnitOfWork(IGenericRepository<Event> genericRepository, IEventRepository eventRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _eventRepository = eventRepository;
        }

        public new async Task<ActionResponse<IEnumerable<Event>>> GetAllAsync()
        {
            return await _eventRepository.GetAllAsync();
        }

        public async Task<ActionResponse<Event>> GetByIdAsync(int id)
        {
            return await _eventRepository.GetByIdAsync(id);
        }
    }
}