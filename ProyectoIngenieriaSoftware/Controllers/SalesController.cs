using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIngenieriaSoftware.Models;

namespace ProyectoIngenieriaSoftware.Controllers
{
    public class SalesController : Controller
    {
        private readonly StoreContext _context;

        public SalesController(StoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> productos =
                          await _context.Products.ToListAsync();

            List<Customer> clientes =
                          await _context.Customers.ToListAsync();

            ViewBag.Productos = new SelectList(productos, "IdProducto", "Descripcion");
            ViewBag.Clientes = new SelectList(clientes, "IdCliente", "Nombre");

            Venta model = new Venta();
            model.FechaVenta = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(VentaViewModel newVenta)
        {
            
            

            // Crear el registro de venta en la tabla "Sales"
            Sale venta = new Sale
            {
                IdVenta = GenerarIdVenta(), // Método para generar un nuevo ID de venta
                FechaVenta = newVenta.fechaCompra,
                IdCliente = newVenta.cliente,
                Total = newVenta.totalVenta
            };


            // Guardar el registro de venta en la base de datos
            _context.Sales.Add(venta);
            _context.SaveChanges();

            int idVenta = venta.IdVenta;

            newVenta.Productos.ForEach(p =>
            {

                // Crear el registro de ítem de venta en la tabla "SalesItems"
                SalesItem itemVenta = new SalesItem
                {
                    IdVenta = idVenta,
                    IdProducto = p.idProducto,
                    Cantidad = p.cantidad,
                    Subtotal = p.subtotal
                };

                // Guardar el registro de ítem de venta en la base de datos
                _context.SalesItems.Add(itemVenta);
                _context.SaveChanges();

            });

            //    return RedirectToAction("Index");


            return Ok();
        }

        public int GenerarIdVenta()
        {
            
            
                int ultimoId;
                // Obtener el último ID de venta
                var ventas = _context.Sales.ToList();
                if(ventas.Count > 0) 
                {
                    ultimoId = _context.Sales.Max(s => s.IdVenta);
                }
                else 
                {
                    ultimoId = 0;
                }
                

                // Generar el siguiente ID sumando 1
                int nuevoId = ultimoId + 1;

                return nuevoId;
            
        }

        public async Task<Decimal> CalcularTotalVenta(int IdProducto, int Cantidad) 
        {

            var producto = await _context.Products.FirstOrDefaultAsync(m => m.IdProducto == IdProducto);

            var impuesto = (double)producto.PrecioUnitario * Cantidad * 0.12; 

            decimal total = (decimal)((double)producto.PrecioUnitario * Cantidad + impuesto);    

            return total; 

        }


        public async Task<Decimal> CalcularSubtotalVenta(int IdProducto, int Cantidad) 
        {
            var producto = await _context.Products.FirstOrDefaultAsync(m => m.IdProducto == IdProducto);

            var total = (decimal)((double)producto.PrecioUnitario * Cantidad);  
                
            return total; 
        }
    }
}
