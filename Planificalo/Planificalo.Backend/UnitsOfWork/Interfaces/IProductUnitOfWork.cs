using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Shared.UnitOfWork
{
    public interface IProductUnitOfWork : IGenericUnitOfWork<Product>
    {
        // Métodos específicos para Product si es necesario
    }
}