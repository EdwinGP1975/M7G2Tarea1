namespace M7Tarea1.Server.Data.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string UnidadVenta { get; set; }

        //Navegacion
        public ICollection<VentaDetalle>? VentaDetalle { get; set; }
        public Descuento? Descuento { get; set; }
    }
}
