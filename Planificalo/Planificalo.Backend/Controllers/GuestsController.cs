using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class GuestsController : GenericController<Guest>
    {
        public GuestsController(IGenericUnitOfWork<Guest> unitOfWork) : base(unitOfWork)
        {
        }
    }
}