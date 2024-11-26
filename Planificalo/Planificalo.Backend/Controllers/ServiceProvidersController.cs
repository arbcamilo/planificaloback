using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using System.Threading.Tasks;
using ServiceProvider = Planificalo.Shared.Entities.ServiceProvider;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Provider,Admin,User")]
    [Route("api/admin/[controller]")]
    public class ServiceProvidersController : GenericController<ServiceProvider>
    {
        private readonly DataContext _context;

        public ServiceProvidersController(IGenericUnitOfWork<ServiceProvider> unitOfWork, DataContext context) : base(unitOfWork)
        {
            _context = context;
        }

        [HttpGet("ByDocumentNumber/{documentNumber}")]
        public async Task<ActionResult<ActionResponse<IEnumerable<ServiceProvider>>>> GetByDocumentNumber(int documentNumber)
        {
            var providers = await _context.ServiceProviders
          .Where(pp => pp.ProviderId == documentNumber)
          .ToListAsync();

            if (providers == null || !providers.Any())
            {
                return NotFound(new ActionResponse<IEnumerable<ServiceProvider>>
                {
                    Success = false,
                    Message = "No providers found with the given document number."
                });
            }

            return Ok(new ActionResponse<IEnumerable<ServiceProvider>>
            {
                Success = true,
                Entity = providers
            });
        }
    }
}