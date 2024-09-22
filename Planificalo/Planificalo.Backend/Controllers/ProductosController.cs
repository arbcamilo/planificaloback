using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ProductosController : GenericController<Producto>
    {
        public ProductosController(IGenericUnitOfWork<Producto> unitOfWork) : base(unitOfWork)
        {
        }
    }
}