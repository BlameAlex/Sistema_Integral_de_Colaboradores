using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabCapacitacion
{
    public int CapacitacionId { get; set; }

    public uint NoNomina { get; set; }

    public string CapacitacionNombre { get; set; } = null!;

    public int CapacitacionTipo { get; set; }

    public virtual ColabCapacitacionTipo CapacitacionTipoNavigation { get; set; } = null!;

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
