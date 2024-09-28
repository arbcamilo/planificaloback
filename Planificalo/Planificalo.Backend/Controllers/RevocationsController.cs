using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class RevocationsController : GenericController<Revocation>
    {
        public RevocationsController(IGenericUnitOfWork<Revocation> unitOfWork) : base(unitOfWork)
        {
        }
    }
}