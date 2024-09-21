namespace M7Tarea1.Server.Data.Models
{
    public class VentaDetalle
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Precio { get; set; }
        public decimal DescuentoItem { get; set; }
        public decimal PrecioDescuento { get; set; }
        public int VentaId { get; set; }

        //Navegacion
        public Venta? Venta { get; set; }
        public ICollection<Producto>? Productos { get; set; }
        public ICollection<Servicio>? Servicios { get; set; }
    }
}
