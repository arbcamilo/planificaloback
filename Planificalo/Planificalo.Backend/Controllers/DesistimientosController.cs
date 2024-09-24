using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class DesistimientosController : GenericController<Desistimiento>
    {
        public DesistimientosController(IGenericUnitOfWork<Desistimiento> unitOfWork) : base(unitOfWork)
        {
        }
    }
}