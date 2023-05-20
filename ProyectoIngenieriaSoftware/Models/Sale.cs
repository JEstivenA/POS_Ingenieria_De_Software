using System;
using System.Collections.Generic;

namespace ProyectoIngenieriaSoftware.Models;

public partial class Sale
{
    public int IdVenta { get; set; }

    public DateTime? FechaVenta { get; set; }

    public int? IdCliente { get; set; }

    public decimal? Total { get; set; }

    public virtual Customer? IdClienteNavigation { get; set; }

    public virtual ICollection<SalesItem> SalesItems { get; } = new List<SalesItem>();
}
