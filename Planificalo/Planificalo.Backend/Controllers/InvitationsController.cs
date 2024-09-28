using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class InvitationsController : GenericController<Invitation>
    {
        public InvitationsController(IGenericUnitOfWork<Invitation> unitOfWork) : base(unitOfWork)
        {
        }
    }
}