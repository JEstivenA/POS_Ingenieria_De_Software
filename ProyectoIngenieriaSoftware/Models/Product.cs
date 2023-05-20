using System;
using System.Collections.Generic;

namespace ProyectoIngenieriaSoftware.Models;

public partial class Product
{
    public int IdProducto { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdMarca { get; set; }

    public int IdCategoria { get; set; }

    public string? Imagen { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual Category IdCategoriaNavigation { get; set; } = null!;

    public virtual Brand IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<SalesItem> SalesItems { get; } = new List<SalesItem>();
}
