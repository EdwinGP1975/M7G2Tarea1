using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace M7Tarea1.Server.Services
{
    public class ServicioGrupoProducto : IServicio
    {
        private readonly ApplicationDbContext _context;
        public ServicioGrupoProducto(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Registrar(Object item)
        {
            GrupoProducto grupoProducto = (GrupoProducto)item;
            _context.GrupoProductos.Add(grupoProducto);
            await _context.SaveChangesAsync();
        }
    }
}
