namespace M7Tarea1.Server.Data.Models
{
    public class Almacen
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string? Direccion { get; set; }

        //Navegacion
        public ICollection<Producto>? Productos { get; set; }

    }
}
