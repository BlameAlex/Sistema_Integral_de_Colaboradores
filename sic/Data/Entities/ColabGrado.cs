using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabGrado
{
    public int GradoFolio { get; set; }

    public uint NoNomina { get; set; }

    public string? GradoNombre { get; set; }

    public string? GradoCedula { get; set; }

    public int? GradoTipo { get; set; }

    public string GradoUltimo { get; set; } = null!;

    public virtual ColabGradosTipo? GradoTipoNavigation { get; set; }

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
