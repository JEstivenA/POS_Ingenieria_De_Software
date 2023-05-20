namespace ProyectoIngenieriaSoftware.Models
{
    public class Venta: Sale
    {
        public int? IdVenta { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Subtotal { get; set; }
    }
}
