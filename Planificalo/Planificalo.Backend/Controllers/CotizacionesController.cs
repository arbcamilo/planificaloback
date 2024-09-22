using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class CotizacionesController : GenericController<Cotizacion>
    {
        public CotizacionesController(IGenericUnitOfWork<Cotizacion> unitOfWork) : base(unitOfWork)
        {
        }
    }
}