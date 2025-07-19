using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabGradosTipo
{
    public int GradoTipoId { get; set; }

    public int? GradoTipo { get; set; }

    public virtual ICollection<ColabGrado> ColabGrados { get; set; } = new List<ColabGrado>();
}
