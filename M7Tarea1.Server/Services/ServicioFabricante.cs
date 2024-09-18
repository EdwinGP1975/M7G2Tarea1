using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;

namespace M7Tarea1.Server.Services
{
    public class ServicioFabricante : IServicio
    {
        public async void Registrar(Object item, ApplicationDbContext context)
        {
            Fabricante fabricante = (Fabricante)item;
            context.Fabricante.Add(fabricante);
            await context.SaveChangesAsync();
        }
    }
}
