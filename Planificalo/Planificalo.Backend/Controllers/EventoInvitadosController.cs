using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class EventoInvitadosController : GenericController<EventoInvitado>
    {
        public EventoInvitadosController(IGenericUnitOfWork<EventoInvitado> unitOfWork) : base(unitOfWork)
        {
        }
    }
}