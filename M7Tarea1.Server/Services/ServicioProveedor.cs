using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;

namespace M7Tarea1.Server.Services
{
    public class ServicioProveedor : IServicio
    {
        private readonly ApplicationDbContext _context;
        public ServicioProveedor(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Registrar(Object item)
        {
            Proveedor proveedor = (Proveedor)item;
            _context.Proveedor.Add(proveedor);
            await _context.SaveChangesAsync();
        }
    }
}
