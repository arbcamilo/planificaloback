using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/admin/[controller]")]
    public class EventsController : GenericController<Event>
    {
        private readonly IEventsUnitOfWork _eventsUnitOfWork;

        public EventsController(IEventsUnitOfWork eventsUnitOfWork) : base(eventsUnitOfWork)
        {
            _eventsUnitOfWork = eventsUnitOfWork;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ActionResponse<IEnumerable<Event>>>> GetAllAsync()
        {
            var response = await _eventsUnitOfWork.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ActionResponse<Event>>> GetById(int id)
        {
            var response = await _eventsUnitOfWork.GetByIdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
    }
}