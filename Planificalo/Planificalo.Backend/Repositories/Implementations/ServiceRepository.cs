using Planificalo.Backend.Data;
using Planificalo.Backend.Repositories.Implementations;
using Planificalo.Shared.Entities;

namespace Planificalo.Shared.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(DataContext context) : base(context)
        {
        }
    }
}