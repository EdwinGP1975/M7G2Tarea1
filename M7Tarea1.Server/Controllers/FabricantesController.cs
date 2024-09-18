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
    public class FabricantesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ServicioFabricante _servicioFabricante;

        public FabricantesController(ApplicationDbContext context, ServicioFabricante servicioFabricante)
        {
            _context = context;
            _servicioFabricante = servicioFabricante;
        }

        // GET: api/Fabricantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fabricante>>> GetFabricante()
        {
            return await _context.Fabricante.ToListAsync();
        }

        // GET: api/Fabricantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fabricante>> GetFabricante(int id)
        {
            var fabricante = await _context.Fabricante.FindAsync(id);

            if (fabricante == null)
            {
                return NotFound();
            }

            return fabricante;
        }

        // PUT: api/Fabricantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricante(int id, Fabricante fabricante)
        {
            if (id != fabricante.Id)
            {
                return BadRequest();
            }

            _context.Entry(fabricante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricanteExists(id))
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

        // POST: api/Fabricantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fabricante>> PostFabricante(Fabricante fabricante)
        {
            await _servicioFabricante.Registrar(fabricante);

            return CreatedAtAction("GetFabricante", new { id = fabricante.Id }, fabricante);
        }

        // DELETE: api/Fabricantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFabricante(int id)
        {
            var fabricante = await _context.Fabricante.FindAsync(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            _context.Fabricante.Remove(fabricante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FabricanteExists(int id)
        {
            return _context.Fabricante.Any(e => e.Id == id);
        }
    }
}
