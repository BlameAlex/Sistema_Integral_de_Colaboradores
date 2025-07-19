using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabCorreo
{
    public string ColabCorreo1 { get; set; } = null!;

    public uint NoNomina { get; set; }

    public string? CorreoTipo { get; set; }

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
