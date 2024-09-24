namespace M7Tarea1.Server.Data.Models
{
    public class GrupoCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        //Navegacion
        public ICollection<Cliente>? Clientes { get; set; }
        public ICollection<Descuento>? Descuento { get; set; }

    }
}
