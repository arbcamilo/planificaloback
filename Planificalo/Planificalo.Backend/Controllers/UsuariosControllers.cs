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
    public class UsuariosControllers : GenericController<Usuario>
    {
        public UsuariosControllers(IGenericUnitOfWork<Usuario> unitOfWork) : base(unitOfWork)
        {
        }
    }
}