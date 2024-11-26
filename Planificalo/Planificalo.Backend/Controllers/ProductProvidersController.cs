using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Provider,Admin,User")]
    [Route("api/admin/[controller]")]
    public class ProductProvidersController : GenericController<ProductProvider>
    {
        private readonly DataContext _context;

        public ProductProvidersController(IGenericUnitOfWork<ProductProvider> unitOfWork, DataContext context) : base(unitOfWork)
        {
            _context = context;
        }

        [HttpGet("ByDocumentNumber/{documentNumber}")]
        public async Task<ActionResult<ActionResponse<IEnumerable<ProductProvider>>>> GetByDocumentNumber(int documentNumber)
        {
            var providers = await _context.ProductProviders
          .Where(pp => pp.ProviderId == documentNumber)
          .ToListAsync();

            if (providers == null || !providers.Any())
            {
                return NotFound(new ActionResponse<IEnumerable<ProductProvider>>
                {
                    Success = false,
                    Message = "No providers found with the given document number."
                });
            }

            return Ok(new ActionResponse<IEnumerable<ProductProvider>>
            {
                Success = true,
                Entity = providers
            });
        }
    }
}