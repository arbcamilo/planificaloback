using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Shared.Entities;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/providers")]
    public class ProveedoresController : ControllerBase
    {
        private readonly DataContext _context;

        public ProveedoresController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(proveedor);
            await _context.SaveChangesAsync();
            return Ok(proveedor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var proveedores = await _context.Proveedores.ToListAsync();
            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(x => x.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProveedor = await _context.Proveedores.FindAsync(id);
            if (existingProveedor == null)
            {
                return NotFound();
            }

            _context.Entry(existingProveedor).CurrentValues.SetValues(proveedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(x => x.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}