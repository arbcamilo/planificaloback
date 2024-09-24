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
    public class ProveedoresController : GenericController<Proveedor>
    {
        public ProveedoresController(IGenericUnitOfWork<Proveedor> unitOfWork) : base(unitOfWork)
        {
        }
    }
}