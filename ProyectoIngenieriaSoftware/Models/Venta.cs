namespace ProyectoIngenieriaSoftware.Models
{
    public class Venta: Sale
    {
        public Venta()
        {
            SaleItems = new List<SalesItem>();
        }
        public int? IdVenta { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Subtotal { get; set; }

        public List<SalesItem> SaleItems { get; set; }
    }

    public class SaleItemViewModel
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
