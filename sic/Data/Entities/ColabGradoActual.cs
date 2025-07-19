using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabGradoActual
{
    public int IdGradoActual { get; set; }

    public uint NoNomina { get; set; }

    public string GradoActual { get; set; } = null!;

    public string GradoInstitucion { get; set; } = null!;

    public string GradoNombre { get; set; } = null!;

    public string GradoNivel { get; set; } = null!;

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
