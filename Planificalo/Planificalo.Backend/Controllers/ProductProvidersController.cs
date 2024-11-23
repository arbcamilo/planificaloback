using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Provider,Admin")]
    [Route("api/admin/[controller]")]
    public class ProductProvidersController : GenericController<ProductProvider>
    {
        public ProductProvidersController(IGenericUnitOfWork<ProductProvider> unitOfWork) : base(unitOfWork)
        {
        }
    }
}