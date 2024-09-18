using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;

namespace M7Tarea1.Server.Services
{
    public class ServicioFabricante : IServicio
    {
        private readonly ApplicationDbContext _context;
        public ServicioFabricante(ApplicationDbContext context) {
            _context = context;
        }
        public async Task Registrar(Object item)
        {
            Fabricante fabricante = (Fabricante)item;
            _context.Fabricante.Add(fabricante);
            await _context.SaveChangesAsync();
        }
    }
}
