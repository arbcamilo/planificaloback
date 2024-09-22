using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class EventosController : GenericController<Evento>
    {
        public EventosController(IGenericUnitOfWork<Evento> unitOfWork) : base(unitOfWork)
        {
        }
    }
}