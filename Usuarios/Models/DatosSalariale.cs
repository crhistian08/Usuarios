using System;
using System.Collections.Generic;

namespace Usuarios.Models;

public partial class DatosSalariale
{
    public int Id { get; set; }

    public int? CedulaEmpleado { get; set; }

    public virtual Empleado? CedulaEmpleadoNavigation { get; set; }
}
