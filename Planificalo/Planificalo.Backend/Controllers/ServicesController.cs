using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using Planificalo.Shared.UnitOfWork;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Provider,Admin")]
    [Route("api/admin/[controller]")]
    public class ServicesController : GenericController<Service>
    {
        private readonly IServiceUnitOfWork _unitOfWork;

        public ServicesController(IServiceUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public override async Task<ActionResult<ActionResponse<Service>>> Add(Service entity)
        {
            if (entity.Quantity < 0)
            {
                return BadRequest(new ActionResponse<Service>
                {
                    Success = false,
                    CodError = "ERR004",
                    Message = "Quantity cannot be negative"
                });
            }

            if (entity.Price < 0)
            {
                return BadRequest(new ActionResponse<Service>
                {
                    Success = false,
                    CodError = "ERR005",
                    Message = "Price cannot be negative"
                });
            }

            return await base.Add(entity);
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult<ActionResponse<Service>>> Update(int id, Service entity)
        {
            if (entity.Quantity < 0)
            {
                return BadRequest(new ActionResponse<Service>
                {
                    Success = false,
                    CodError = "ERR004",
                    Message = "Quantity cannot be negative"
                });
            }

            if (entity.Price < 0)
            {
                return BadRequest(new ActionResponse<Service>
                {
                    Success = false,
                    CodError = "ERR005",
                    Message = "Price cannot be negative"
                });
            }

            return await base.Update(id, entity);
        }
    }
}