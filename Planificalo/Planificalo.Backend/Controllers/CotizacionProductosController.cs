using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class CotizacionesProductosController : GenericController<CotizacionProducto>
    {
        public CotizacionesProductosController(IGenericUnitOfWork<CotizacionProducto> unitOfWork) : base(unitOfWork)
        {
        }
    }
}