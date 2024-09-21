namespace M7Tarea1.Server.Data.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateOnly Fecha { get; set; }
        public int NitFacturacion { get; set; }
        public string NombreFacturacion { get; set; }
        public bool ConIva { get; set; }
        public decimal DescuentoGlobal { get; set; }
        public decimal PrecioTotal { get; set; }
        //precio total despues de aplicar el descuento global
        public decimal PrecioTotalDescuento {  get; set; }
        public int ClienteId { get; set; }

        //Navegacion
        public Cliente? Cliente { get; set; }
        public ICollection<VentaDetalle>? VentaDetalle { get; set; }

    }
}
