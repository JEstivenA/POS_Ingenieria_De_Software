using System;
using System.Collections.Generic;

namespace ProyectoIngenieriaSoftware.Models;

public partial class Inventory
{
    public int IdInventory { get; set; }

    public DateTime DateIn { get; set; }

    public DateTime DateOut { get; set; }

    public int IdProduct { get; set; }

    public int StockIn { get; set; }

    public int Entries { get; set; }

    public int Outlets { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;
}
