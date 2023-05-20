using System;
using System.Collections.Generic;

namespace ProyectoIngenieriaSoftware.Models;

public partial class Customer
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
