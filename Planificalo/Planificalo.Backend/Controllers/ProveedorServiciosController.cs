using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Shared.Entities;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/providerservices")]
    public class ProveedorServiciosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProveedorServiciosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProveedorServicio proveedorServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(proveedorServicio);
            await _context.SaveChangesAsync();
            return Ok(proveedorServicio);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var proveedorServicios = await _context.ProveedorServicios
                .Include(ps => ps.Proveedor)
                .Include(ps => ps.Servicio)
                .ToListAsync();
            return Ok(proveedorServicios);
        }

        [HttpGet("{proveedorId}/{servicioId}")]
        public async Task<IActionResult> GetAsync(int proveedorId, int servicioId)
        {
            var proveedorServicio = await _context.ProveedorServicios
                .Include(ps => ps.Proveedor)
                .Include(ps => ps.Servicio)
                .FirstOrDefaultAsync(x => x.ProveedorId == proveedorId && x.ServicioId == servicioId);
            if (proveedorServicio == null)
            {
                return NotFound();
            }
            return Ok(proveedorServicio);
        }

        [HttpDelete("{proveedorId}/{servicioId}")]
        public async Task<IActionResult> DeleteAsync(int proveedorId, int servicioId)
        {
            var proveedorServicio = await _context.ProveedorServicios
                .FirstOrDefaultAsync(x => x.ProveedorId == proveedorId && x.ServicioId == servicioId);
            if (proveedorServicio == null)
            {
                return NotFound();
            }
            _context.ProveedorServicios.Remove(proveedorServicio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}