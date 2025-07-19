using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class InformacionHijo
{
    public string HijoCurp { get; set; } = null!;

    public uint NoNomina { get; set; }

    public string? HijoNombre { get; set; }

    public DateOnly? HijoFechaNac { get; set; }

    public string? HijoSexo { get; set; }

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
