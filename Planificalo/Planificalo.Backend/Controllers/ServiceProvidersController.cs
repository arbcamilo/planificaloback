using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using System.Threading.Tasks;
using ServiceProvider = Planificalo.Shared.Entities.ServiceProvider;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Provider,Admin")]
    [Route("api/admin/[controller]")]
    public class ServiceProvidersController : GenericController<ServiceProvider>
    {
        public ServiceProvidersController(IGenericUnitOfWork<ServiceProvider> unitOfWork) : base(unitOfWork)
        {
        }
    }
}