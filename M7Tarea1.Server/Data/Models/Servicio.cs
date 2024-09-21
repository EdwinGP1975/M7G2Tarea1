namespace M7Tarea1.Server.Data.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string UnidadVenta { get; set; }
        public int VentaDetalleId { get; set; }

        //Navegacion
        public VentaDetalle? VentaDetalle { get; set; }
    }
}
