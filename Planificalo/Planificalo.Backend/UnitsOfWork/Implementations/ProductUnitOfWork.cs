using Planificalo.Backend.UnitsOfWork.Implementations;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Repositories;

namespace Planificalo.Shared.UnitOfWork
{
    public class ProductUnitOfWork : GenericUnitOfWork<Product>, IProductUnitOfWork
    {
        public ProductUnitOfWork(IProductRepository productRepository) : base(productRepository)
        {
        }
    }
}