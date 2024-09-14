using Microsoft.AspNetCore.Mvc;
using Planificalo.Backend.Data;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/users")]
    public class UsersControllers : ControllerBase
    {
        private readonly DataContext _context;

        public UsersControllers(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}