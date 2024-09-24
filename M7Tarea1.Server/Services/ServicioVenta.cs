
using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioVenta : IServicio
    {
        private readonly ApplicationDbContext _context;
        public ServicioVenta(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task Registrar(object item)
        {
            Venta venta = (Venta)item;
            _context.Venta.Add(venta);
            await _context.SaveChangesAsync();
        }
    }
}
