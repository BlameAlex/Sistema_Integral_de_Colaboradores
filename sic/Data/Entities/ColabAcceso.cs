using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabAcceso
{
    public string AccesoUser { get; set; } = null!;

    public uint NoNomina { get; set; }

    public string AccesoContrasena { get; set; } = null!;

    public int AccesoPermiso { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual Permiso AccesoPermisoNavigation { get; set; } = null!;

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
