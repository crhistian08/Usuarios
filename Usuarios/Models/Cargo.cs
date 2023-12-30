using System;
using System.Collections.Generic;

namespace Usuarios.Models;

public partial class Cargo
{
    public int CodigoCargo { get; set; }

    public string? NombreCargo { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
