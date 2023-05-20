using System;
using System.Collections.Generic;

namespace ProyectoIngenieriaSoftware.Models;

public partial class Usser
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Ussers { get; set; } = null!;

    public string Pswd { get; set; } = null!;

    public string TypeUsser { get; set; } = null!;
}
