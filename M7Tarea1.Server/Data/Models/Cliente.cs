namespace M7Tarea1.Server.Data.Models
{
    public abstract class Cliente
    {
        public int Id { get; set; }
        public string Codigo {get; set;}
        public string Email { get; set; }
        public int GrupoClienteId { get; set; }

        //Navegacion
        public GrupoCliente? GrupoCliente { get; set; }
        public Venta Venta { get; set; }

    }
}
