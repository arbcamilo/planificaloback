using Planificalo.Backend.Data;
using Planificalo.Backend.Repositories.Implementations;
using Planificalo.Shared.Entities;

namespace Planificalo.Shared.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}