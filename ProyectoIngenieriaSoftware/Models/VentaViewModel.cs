namespace ProyectoIngenieriaSoftware.Models
{
    public class VentaViewModel
    {
        public VentaViewModel() 
        {
            Productos = new List<ProductoViewModel>();
        }
        public int cliente { get; set; }
        public DateTime fechaCompra { get; set; }
        public decimal totalVenta { get; set; }

        public List<ProductoViewModel> Productos { get; set; }

    }

    public class ProductoViewModel
    {
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
    }
}
