using System;
using System.Collections.Generic;

namespace Usuarios.Models;

public partial class Empleado
{
    public int Cedula { get; set; }

    public string? Nombre1 { get; set; }

    public string? Nombre2 { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public int? CodigoCargo { get; set; }

    public virtual Cargo? CodigoCargoNavigation { get; set; }

    public virtual ICollection<DatosSalariale> DatosSalariales { get; set; } = new List<DatosSalariale>();
}
