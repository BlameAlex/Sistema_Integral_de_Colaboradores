using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class Permiso
{
    public int PermisosId { get; set; }

    public string PermisosTipo { get; set; } = null!;
}
