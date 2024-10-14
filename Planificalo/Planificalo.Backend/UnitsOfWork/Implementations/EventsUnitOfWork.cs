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
        private readonly IGenericRepository<Event> _repository;

        public EventsUnitOfWork(IGenericRepository<Event> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ActionResponse<IEnumerable<Event>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}