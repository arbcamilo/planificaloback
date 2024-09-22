using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class TiposEventoController : GenericController<TipoEvento>
    {
        public TiposEventoController(IGenericUnitOfWork<TipoEvento> unitOfWork) : base(unitOfWork)
        {
        }
    }
}