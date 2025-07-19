using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class ColabExpLaboral
{
    public sbyte IdExpLaboral { get; set; }

    public uint NoNomina { get; set; }

    public string EmpresaNombre { get; set; } = null!;

    public DateOnly TrabajoInicio { get; set; }

    public DateOnly TrabajoFin { get; set; }

    public string TrabajoPuesto { get; set; } = null!;

    public string TrabajoArea { get; set; } = null!;

    public int TrabajoSueldo { get; set; }

    public string JefeNombre { get; set; } = null!;

    public string JefePuesto { get; set; } = null!;

    public string JefeCel { get; set; } = null!;

    public string TrabajoRazonSepracion { get; set; } = null!;

    public virtual InfoColaborador NoNominaNavigation { get; set; } = null!;
}
