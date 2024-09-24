using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using M7Tarea1.Server.Services;

namespace M7Tarea1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaDetalleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ServicioVentaDetalle _servicioVentaDetalle;

        public VentaDetalleController(ApplicationDbContext context, ServicioVentaDetalle servicioVentaDetalle)
        {
            _context = context;
            _servicioVentaDetalle = servicioVentaDetalle;
        }

        // GET: api/VentaDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaDetalle>>> GetVentaDetalle()
        {
            return await _context.VentaDetalle.ToListAsync();
        }

        // GET: api/VentaDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDetalle>> GetVentaDetalle(int id)
        {
            var ventaDetalle = await _context.VentaDetalle.FindAsync(id);

            if (ventaDetalle == null)
            {
                return NotFound();
            }

            return ventaDetalle;
        }

        // PUT: api/VentaDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentaDetalle(int id, VentaDetalle ventaDetalle)
        {
            if (id != ventaDetalle.Id)
            {
                return BadRequest();
            }

            _context.Entry(ventaDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaDetalleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VentaDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VentaDetalle>> PostVentaDetalle(VentaDetalle ventaDetalle)
        {
            await _servicioVentaDetalle.Registrar(ventaDetalle);

            return CreatedAtAction("GetVentaDetalle", new { id = ventaDetalle.Id }, ventaDetalle);
        }

        // DELETE: api/VentaDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentaDetalle(int id)
        {
            var ventaDetalle = await _context.VentaDetalle.FindAsync(id);
            if (ventaDetalle == null)
            {
                return NotFound();
            }

            _context.VentaDetalle.Remove(ventaDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaDetalleExists(int id)
        {
            return _context.VentaDetalle.Any(e => e.Id == id);
        }
    }
}
