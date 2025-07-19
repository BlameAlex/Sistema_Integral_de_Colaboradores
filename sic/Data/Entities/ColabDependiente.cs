using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabDependiente
{
    public int IdDependiente { get; set; }

    public uint NoNomina { get; set; }

    public string? DependienteNombre { get; set; }

    public string? DependienteParentesco { get; set; }

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
