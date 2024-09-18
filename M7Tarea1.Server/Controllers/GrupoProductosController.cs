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
    public class GrupoProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ServicioGrupoProducto _grupoProductos;
        public GrupoProductosController(ApplicationDbContext context, ServicioGrupoProducto grupoProducto)
        {
            _context = context;
            _grupoProductos = grupoProducto;
        }

        // GET: api/GrupoProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoProducto>>> GetGrupoProductos()
        {
            return await _context.GrupoProductos.ToListAsync();
        }

        // GET: api/GrupoProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoProducto>> GetGrupoProducto(int id)
        {
            var grupoProducto = await _context.GrupoProductos.FindAsync(id);

            if (grupoProducto == null)
            {
                return NotFound();
            }

            return grupoProducto;
        }

        // PUT: api/GrupoProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoProducto(int id, GrupoProducto grupoProducto)
        {
            if (id != grupoProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoProductoExists(id))
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

        // POST: api/GrupoProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoProducto>> PostGrupoProducto(GrupoProducto grupoProducto)
        {
            await _grupoProductos.Registrar(grupoProducto);
            
            return CreatedAtAction("GetGrupoProducto", new { id = grupoProducto.Id }, grupoProducto);
        }

        // DELETE: api/GrupoProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoProducto(int id)
        {
            var grupoProducto = await _context.GrupoProductos.FindAsync(id);
            if (grupoProducto == null)
            {
                return NotFound();
            }

            _context.GrupoProductos.Remove(grupoProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoProductoExists(int id)
        {
            return _context.GrupoProductos.Any(e => e.Id == id);
        }
    }
}
