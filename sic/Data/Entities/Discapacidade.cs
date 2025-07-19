using System;
using System.Collections.Generic;

namespace sic.Models;

/// <summary>
/// Discapacidades con concatenación en back
/// </summary>
public partial class Discapacidade
{
    public int DiscapacidadId { get; set; }

    public uint NoNomina { get; set; }

    public string Discapacidades { get; set; } = null!;

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
