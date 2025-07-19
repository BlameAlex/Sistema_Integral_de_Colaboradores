using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabCapacitacionTipo
{
    public int CapacitacionTipoId { get; set; }

    public string CapacitacionTipo { get; set; } = null!;

    public virtual ICollection<ColabCapacitacion> ColabCapacitacions { get; set; } = new List<ColabCapacitacion>();
}
