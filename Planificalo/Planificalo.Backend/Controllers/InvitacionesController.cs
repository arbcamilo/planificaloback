using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class InvitacionesController : GenericController<Invitacion>
    {
        public InvitacionesController(IGenericUnitOfWork<Invitacion> unitOfWork) : base(unitOfWork)
        {
        }
    }
}