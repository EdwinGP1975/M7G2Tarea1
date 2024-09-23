using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;

namespace M7Tarea1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GrupoClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GrupoClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoCliente>>> GetGrupoCliente()
        {
            return await _context.GrupoCliente.ToListAsync();
        }

        // GET: api/GrupoClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoCliente>> GetGrupoCliente(int id)
        {
            var grupoCliente = await _context.GrupoCliente.FindAsync(id);

            if (grupoCliente == null)
            {
                return NotFound();
            }

            return grupoCliente;
        }

        // PUT: api/GrupoClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoCliente(int id, GrupoCliente grupoCliente)
        {
            if (id != grupoCliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoClienteExists(id))
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

        // POST: api/GrupoClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoCliente>> PostGrupoCliente(GrupoCliente grupoCliente)
        {
            _context.GrupoCliente.Add(grupoCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoCliente", new { id = grupoCliente.Id }, grupoCliente);
        }

        // DELETE: api/GrupoClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoCliente(int id)
        {
            var grupoCliente = await _context.GrupoCliente.FindAsync(id);
            if (grupoCliente == null)
            {
                return NotFound();
            }

            _context.GrupoCliente.Remove(grupoCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoClienteExists(int id)
        {
            return _context.GrupoCliente.Any(e => e.Id == id);
        }
    }
}
