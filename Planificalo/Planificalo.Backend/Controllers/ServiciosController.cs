using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ServiciosController : GenericController<Servicio>
    {
        public ServiciosController(IGenericUnitOfWork<Servicio> unitOfWork) : base(unitOfWork)
        {
        }
    }
}