using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabCel
{
    public int ColabCel1 { get; set; }

    public uint NoNomina { get; set; }

    public string CelTipo { get; set; } = null!;

    public int? Ext { get; set; }

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
