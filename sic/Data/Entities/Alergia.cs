using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class Alergia
{
    public int AlergiasId { get; set; }

    public uint NoNomina { get; set; }

    public string AlergiasDescripcion { get; set; } = null!;

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
