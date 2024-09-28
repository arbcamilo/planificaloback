using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ServicesController : GenericController<Service>
    {
        public ServicesController(IGenericUnitOfWork<Service> unitOfWork) : base(unitOfWork)
        {
        }
    }
}