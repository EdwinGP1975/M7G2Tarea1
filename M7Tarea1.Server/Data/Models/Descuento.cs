namespace M7Tarea1.Server.Data.Models
{
    public class Descuento
    {
        public int Id { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }

        public int? ProductoId { get; set; }
        public int? GrupoClienteId { get; set; }



        // Navegacion
        public Producto? Producto { get; set; }
        public GrupoCliente? GrupoCliente { get; set; }
    }
}
