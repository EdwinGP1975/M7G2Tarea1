
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioDescuento : IServicio
    {
        private readonly ApplicationDbContext _context;
        public ServicioDescuento(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Descuento> GetDescuento(int descuentoId)
        {
            var descuento = await _context.Descuento.FindAsync(descuentoId);

            return descuento;
        }
        public async Task Registrar(object item)
        {
            Descuento descuento = (Descuento)item;
            _context.Descuento.Add(descuento);
            await _context.SaveChangesAsync();
        }

        public async Task<Descuento> GetDescuentoGrupoCliente(int grupoClienteId)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var descuento = await _context.Descuento.FirstOrDefaultAsync(d => d.GrupoClienteId == grupoClienteId
                && d.FechaInicio <= today && d.FechaFin >= today);

            return descuento;
        }

        public async Task<Descuento> GetDescuentoProducto(int productoId)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var descuento = await _context.Descuento.FirstOrDefaultAsync(d => d.ProductoId == productoId
                && d.FechaInicio <= today && d.FechaFin >= today);

            return descuento;
        }
    }
}
