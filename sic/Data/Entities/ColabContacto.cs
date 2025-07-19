using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabContacto
{
    public string ContactoCelular { get; set; } = null!;

    public uint NoNomina { get; set; }

    public string ContactoNombre { get; set; } = null!;

    public string ContactoParentesco { get; set; } = null!;

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
