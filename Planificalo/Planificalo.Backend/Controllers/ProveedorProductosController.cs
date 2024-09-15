using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Shared.Entities;
using System.Threading.Tasks;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/providerproducts")]
    public class ProveedorProductosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProveedorProductosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProveedorProducto proveedorProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(proveedorProducto);
            await _context.SaveChangesAsync();
            return Ok(proveedorProducto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var proveedorProductos = await _context.ProveedorProductos
                .Include(pp => pp.Proveedor)
                .Include(pp => pp.Producto)
                .ToListAsync();
            return Ok(proveedorProductos);
        }

        [HttpGet("{proveedorId}/{productoId}")]
        public async Task<IActionResult> GetAsync(int proveedorId, int productoId)
        {
            var proveedorProducto = await _context.ProveedorProductos
                .Include(pp => pp.Proveedor)
                .Include(pp => pp.Producto)
                .FirstOrDefaultAsync(x => x.ProveedorId == proveedorId && x.ProductoId == productoId);
            if (proveedorProducto == null)
            {
                return NotFound();
            }
            return Ok(proveedorProducto);
        }

        [HttpDelete("{proveedorId}/{productoId}")]
        public async Task<IActionResult> DeleteAsync(int proveedorId, int productoId)
        {
            var proveedorProducto = await _context.ProveedorProductos
                .FirstOrDefaultAsync(x => x.ProveedorId == proveedorId && x.ProductoId == productoId);
            if (proveedorProducto == null)
            {
                return NotFound();
            }
            _context.ProveedorProductos.Remove(proveedorProducto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}