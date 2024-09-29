using Planificalo.Backend.UnitsOfWork.Implementations;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Repositories;

namespace Planificalo.Shared.UnitOfWork
{
    public class ServiceUnitOfWork : GenericUnitOfWork<Service>, IServiceUnitOfWork
    {
        public ServiceUnitOfWork(IServiceRepository serviceRepository) : base(serviceRepository)
        {
        }
    }
}