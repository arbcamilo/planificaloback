using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class InvitadosController : GenericController<Invitado>
    {
        public InvitadosController(IGenericUnitOfWork<Invitado> unitOfWork) : base(unitOfWork)
        {
        }
    }
}