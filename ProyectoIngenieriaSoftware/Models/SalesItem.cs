using System;
using System.Collections.Generic;

namespace ProyectoIngenieriaSoftware.Models;

public partial class SalesItem
{
    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public int SalesItemId { get; set; }

    public virtual Product? IdProductoNavigation { get; set; }

    public virtual Sale? IdVentaNavigation { get; set; }
}
