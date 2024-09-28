using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IGenericUnitOfWork<Product> unitOfWork) : base(unitOfWork)
        {
        }
    }
}