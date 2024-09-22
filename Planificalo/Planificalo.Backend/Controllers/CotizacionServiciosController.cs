using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class CotizacionServiciosController : GenericController<CotizacionServicio>
    {
        public CotizacionServiciosController(IGenericUnitOfWork<CotizacionServicio> unitOfWork) : base(unitOfWork)
        {
        }
    }
}