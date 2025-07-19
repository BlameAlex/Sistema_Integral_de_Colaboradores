using System;
using System.Collections.Generic;

namespace sic.Models;

public partial class InfoColaborador
{
    public uint NoNomina { get; set; }

    public string ColabNombres { get; set; } = null!;

    public string ColabApPaterno { get; set; } = null!;

    public string ColabApMaterno { get; set; } = null!;

    public string ColabRfc { get; set; } = null!;

    public string ColabCurp { get; set; } = null!;

    public DateOnly ColabFechaNac { get; set; }

    public uint ColabSexo { get; set; }

    public string ColabEstCivil { get; set; } = null!;

    public int ColabPais { get; set; }

    public DateTime ColabFechaAlta { get; set; }

    public DateTime? ColabFechaBaja { get; set; }

    public DateTime? ColabAltaIsste { get; set; }

    public string ColabNss { get; set; } = null!;

    public sbyte ColabLentes { get; set; }

    public string? ColabCpSat { get; set; }

    public uint? ColabSalario { get; set; }

    public string ColabTipoSangre { get; set; } = null!;

    public string ColabDireccion { get; set; } = null!;

    public string ColabColonia { get; set; } = null!;

    public string ColabManz { get; set; } = null!;

    public string ColabLote { get; set; } = null!;

    public string ColabNumInt { get; set; } = null!;

    public string ColabNumExt { get; set; } = null!;

    public string ColabCp { get; set; } = null!;

    public string ColabCalle { get; set; } = null!;

    public string ColabAv { get; set; } = null!;

    public string ColabFracc { get; set; } = null!;

    public string ColabEstado { get; set; } = null!;

    public string? ColabPuesto { get; set; }

    public string? ColabPaqueteria { get; set; }

    public string? ColabLenguajeProgramacion { get; set; }

    public string? ColabLenguaIndigena { get; set; }

    public sbyte? ColabTrayectoriaAnios { get; set; }

    public sbyte? ColabGobierno { get; set; }

    public virtual ICollection<Alergia> Alergia { get; set; } = new List<Alergia>();

    public virtual ICollection<ColabCapacitacion> ColabCapacitacions { get; set; } = new List<ColabCapacitacion>();

    public virtual ICollection<ColabCel> ColabCels { get; set; } = new List<ColabCel>();

    public virtual ICollection<ColabContacto> ColabContactos { get; set; } = new List<ColabContacto>();

    public virtual ICollection<ColabCorreo> ColabCorreos { get; set; } = new List<ColabCorreo>();

    public virtual ICollection<ColabDependiente> ColabDependientes { get; set; } = new List<ColabDependiente>();

    public virtual ICollection<ColabExpLaboral> ColabExpLaborals { get; set; } = new List<ColabExpLaboral>();

    public virtual ICollection<ColabGradoActual> ColabGradoActuals { get; set; } = new List<ColabGradoActual>();

    public virtual ICollection<ColabGrado> ColabGrados { get; set; } = new List<ColabGrado>();

    public virtual ICollection<ColabIdioma> ColabIdiomas { get; set; } = new List<ColabIdioma>();

    public virtual ICollection<Discapacidade> Discapacidades { get; set; } = new List<Discapacidade>();

    public virtual ICollection<InformacionHijo> InformacionHijos { get; set; } = new List<InformacionHijo>();
}
