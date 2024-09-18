using M7Tarea1.Server.Data;

namespace M7Tarea1.Server.Services
{
    public interface IServicio
    {
        public void Registrar(Object item, ApplicationDbContext context);
        //public void Map(Object source, Object Destiny);
    }
}
