using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class EventsController : GenericController<Event>
    {
        public EventsController(IGenericUnitOfWork<Event> unitOfWork) : base(unitOfWork)
        {
        }
    }
}