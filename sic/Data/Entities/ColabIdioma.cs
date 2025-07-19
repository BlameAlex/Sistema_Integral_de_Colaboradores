using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabIdioma
{
    public byte IdColabIdioma { get; set; }

    public uint NoNomina { get; set; }

    public string? IdiomaNombre { get; set; }

    public string? IdiomaDominio { get; set; }

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
