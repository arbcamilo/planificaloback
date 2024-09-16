using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ProveedorServiciosController : GenericController<ProveedorServicio>
    {
        public ProveedorServiciosController(IGenericUnitOfWork<ProveedorServicio> unitOfWork) : base(unitOfWork)
        {
        }
    }
}