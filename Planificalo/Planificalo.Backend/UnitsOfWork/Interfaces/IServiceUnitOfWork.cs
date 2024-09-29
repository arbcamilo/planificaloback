using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Shared.UnitOfWork
{
    public interface IServiceUnitOfWork : IGenericUnitOfWork<Service>
    {
        // Métodos específicos para Service si es necesario
    }
}