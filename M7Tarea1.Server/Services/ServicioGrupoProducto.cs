using M7Tarea1.Server.Data;
using M7Tarea1.Server.Data.Models;

namespace M7Tarea1.Server.Services
{
    public class ServicioGrupoProducto : IServicio
    {
        public void Registrar(Object item, ApplicationDbContext context)
        {
            GrupoProducto producto = (GrupoProducto)item;
        }
    }
}
