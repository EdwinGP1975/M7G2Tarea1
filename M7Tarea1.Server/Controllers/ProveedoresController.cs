﻿using System;
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
    public class ProveedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ServicioProveedor _servicioProveedor;

        public ProveedoresController(ApplicationDbContext context, ServicioProveedor servicioProveedor)
        {
            _context = context;
            _servicioProveedor = servicioProveedor;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedor()
        {
            return await _context.Proveedor.ToListAsync();
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // PUT: api/Proveedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
            await _servicioProveedor.Registrar(proveedor);
            
            return CreatedAtAction("GetProveedor", new { id = proveedor.Id }, proveedor);
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var proveedor = await _context.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedor.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.Id == id);
        }
    }
}
