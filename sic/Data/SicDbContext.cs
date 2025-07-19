using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using sic.Models;

namespace sic.Data;

public partial class SicDbContext : DbContext
{
    public SicDbContext()
    {
    }

    public SicDbContext(DbContextOptions<SicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alergia> Alergias { get; set; }

    public virtual DbSet<ColabAcceso> ColabAccesos { get; set; }

    public virtual DbSet<ColabCapacitacion> ColabCapacitacion { get; set; }

    public virtual DbSet<ColabCapacitacionTipo> ColabCapacitacionTipos { get; set; }

    public virtual DbSet<ColabCel> ColabCels { get; set; }

    public virtual DbSet<ColabContacto> ColabContactos { get; set; }

    public virtual DbSet<ColabCorreo> ColabCorreos { get; set; }

    public virtual DbSet<ColabDependiente> ColabDependientes { get; set; }

    public virtual DbSet<ColabExpLaboral> ColabExpLaborals { get; set; }

    public virtual DbSet<ColabGrado> ColabGrados { get; set; }

    public virtual DbSet<ColabGradoActual> ColabGradoActuals { get; set; }

    public virtual DbSet<ColabGradosTipo> ColabGradosTipos { get; set; }

    public virtual DbSet<ColabIdioma> ColabIdiomas { get; set; }

    public virtual DbSet<Discapacidade> Discapacidades { get; set; }

    public virtual DbSet<InfoColaborador> InfoColaboradors { get; set; }

    public virtual DbSet<InformacionHijo> InformacionHijos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Chelsea040426;database=sic_bd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alergia>(entity =>
        {
            entity.HasKey(e => e.AlergiasId).HasName("PRIMARY");

            entity.ToTable("alergias");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.AlergiasId).HasColumnName("alergias_id");
            entity.Property(e => e.AlergiasDescripcion)
                .HasColumnType("text")
                .HasColumnName("alergias_descripcion");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.Alergia)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_alergia_no_nomina");
        });

        modelBuilder.Entity<ColabAcceso>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("colab_acceso");

            entity.HasIndex(e => e.AccesoPermiso, "fk_permisos_tipos_idx");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.AccesoContrasena)
                .HasMaxLength(32)
                .HasColumnName("acceso_contrasena");
            entity.Property(e => e.AccesoPermiso).HasColumnName("acceso_permiso");
            entity.Property(e => e.AccesoUser)
                .HasMaxLength(16)
                .HasColumnName("acceso_user");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("create_time");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.AccesoPermisoNavigation).WithMany()
                .HasForeignKey(d => d.AccesoPermiso)
                .HasConstraintName("fk_permisos_tipos");

            entity.HasOne(d => d.NoNominaNavigation).WithMany()
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("no_nomina");
        });

        modelBuilder.Entity<ColabCapacitacion>(entity =>
        {
            entity.HasKey(e => e.CapacitacionId).HasName("PRIMARY");

            entity.ToTable("colab_capacitacion");

            entity.HasIndex(e => e.CapacitacionTipo, "fk_capacitacion_tipo_capacitacion_tipo_id_idx");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.CapacitacionId)
                .ValueGeneratedNever()
                .HasColumnName("capacitacion_id");
            entity.Property(e => e.CapacitacionNombre)
                .HasMaxLength(100)
                .HasColumnName("capacitacion_nombre");
            entity.Property(e => e.CapacitacionTipo).HasColumnName("capacitacion_tipo");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.CapacitacionTipoNavigation).WithMany(p => p.ColabCapacitacions)
                .HasForeignKey(d => d.CapacitacionTipo)
                .HasConstraintName("fk_capacitacion_tipo_capacitacion_tipo_id");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabCapacitacions)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_capacitacion_no_nomina");
        });

        modelBuilder.Entity<ColabCapacitacionTipo>(entity =>
        {
            entity.HasKey(e => e.CapacitacionTipoId).HasName("PRIMARY");

            entity.ToTable("colab_capacitacion_tipo");

            entity.Property(e => e.CapacitacionTipoId).HasColumnName("capacitacion_tipo_id");
            entity.Property(e => e.CapacitacionTipo)
                .HasMaxLength(45)
                .HasColumnName("capacitacion_tipo");
        });

        modelBuilder.Entity<ColabCel>(entity =>
        {
            entity.HasKey(e => e.ColabCel1).HasName("PRIMARY");

            entity.ToTable("colab_cel");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.ColabCel1)
                .ValueGeneratedNever()
                .HasColumnName("colab_cel");
            entity.Property(e => e.CelTipo)
                .HasColumnType("enum('Personal','Casa','Trabajo')")
                .HasColumnName("cel_tipo");
            entity.Property(e => e.Ext).HasColumnName("ext");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabCels)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_cel_no_nomina");
        });

        modelBuilder.Entity<ColabContacto>(entity =>
        {
            entity.HasKey(e => e.ContactoCelular).HasName("PRIMARY");

            entity.ToTable("colab_contacto");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.ContactoCelular)
                .HasMaxLength(45)
                .HasColumnName("contacto_celular");
            entity.Property(e => e.ContactoNombre)
                .HasMaxLength(45)
                .HasColumnName("contacto_nombre");
            entity.Property(e => e.ContactoParentesco)
                .HasMaxLength(45)
                .HasColumnName("contacto_parentesco");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabContactos)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_contacto_no_nomina");
        });

        modelBuilder.Entity<ColabCorreo>(entity =>
        {
            entity.HasKey(e => e.ColabCorreo1).HasName("PRIMARY");

            entity.ToTable("colab_correo");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.ColabCorreo1)
                .HasMaxLength(45)
                .HasColumnName("colab_correo");
            entity.Property(e => e.CorreoTipo)
                .HasColumnType("enum('Personal','Institucional')")
                .HasColumnName("correo_tipo");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabCorreos)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_correo_no_nomina");
        });

        modelBuilder.Entity<ColabDependiente>(entity =>
        {
            entity.HasKey(e => e.IdDependiente).HasName("PRIMARY");

            entity.ToTable("colab_dependientes");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.IdDependiente).HasColumnName("id_dependiente");
            entity.Property(e => e.DependienteNombre)
                .HasMaxLength(50)
                .HasColumnName("dependiente_nombre");
            entity.Property(e => e.DependienteParentesco)
                .HasMaxLength(45)
                .HasColumnName("dependiente_parentesco");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabDependientes)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_dependientes_no_nomina");
        });

        modelBuilder.Entity<ColabExpLaboral>(entity =>
        {
            entity.HasKey(e => e.IdExpLaboral).HasName("PRIMARY");

            entity.ToTable("colab_exp_laboral");

            entity.HasIndex(e => e.NoNomina, "fk_exp_no_nomina_idx");

            entity.Property(e => e.IdExpLaboral)
                .ValueGeneratedNever()
                .HasColumnName("id_exp_laboral");
            entity.Property(e => e.EmpresaNombre)
                .HasMaxLength(45)
                .HasColumnName("empresa_nombre");
            entity.Property(e => e.JefeCel)
                .HasMaxLength(45)
                .HasColumnName("jefe_cel");
            entity.Property(e => e.JefeNombre)
                .HasMaxLength(50)
                .HasColumnName("jefe_nombre");
            entity.Property(e => e.JefePuesto)
                .HasMaxLength(100)
                .HasColumnName("jefe_puesto");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");
            entity.Property(e => e.TrabajoArea)
                .HasMaxLength(100)
                .HasColumnName("trabajo_area");
            entity.Property(e => e.TrabajoFin).HasColumnName("trabajo_fin");
            entity.Property(e => e.TrabajoInicio).HasColumnName("trabajo_inicio");
            entity.Property(e => e.TrabajoPuesto)
                .HasMaxLength(100)
                .HasColumnName("trabajo_puesto");
            entity.Property(e => e.TrabajoRazonSepracion)
                .HasColumnType("text")
                .HasColumnName("trabajo_razon_sepracion");
            entity.Property(e => e.TrabajoSueldo).HasColumnName("trabajo_sueldo");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabExpLaborals)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_exp_no_nomina");
        });

        modelBuilder.Entity<ColabGrado>(entity =>
        {
            entity.HasKey(e => e.GradoFolio).HasName("PRIMARY");

            entity.ToTable("colab_grados");

            entity.HasIndex(e => e.GradoTipo, "fk_grado_tipo_idx");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.GradoFolio)
                .ValueGeneratedNever()
                .HasColumnName("grado_folio");
            entity.Property(e => e.GradoCedula)
                .HasMaxLength(45)
                .HasColumnName("grado_cedula");
            entity.Property(e => e.GradoNombre)
                .HasMaxLength(45)
                .HasColumnName("grado_nombre");
            entity.Property(e => e.GradoTipo).HasColumnName("grado_tipo");
            entity.Property(e => e.GradoUltimo)
                .HasMaxLength(45)
                .HasColumnName("grado_ultimo");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.GradoTipoNavigation).WithMany(p => p.ColabGrados)
                .HasForeignKey(d => d.GradoTipo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_grado_tipo");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabGrados)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_grado_no_nomina");
        });

        modelBuilder.Entity<ColabGradoActual>(entity =>
        {
            entity.HasKey(e => e.IdGradoActual).HasName("PRIMARY");

            entity.ToTable("colab_grado_actual");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.IdGradoActual)
                .ValueGeneratedNever()
                .HasColumnName("id_grado_actual");
            entity.Property(e => e.GradoActual)
                .HasMaxLength(45)
                .HasColumnName("grado_actual");
            entity.Property(e => e.GradoInstitucion)
                .HasMaxLength(45)
                .HasColumnName("grado_institucion");
            entity.Property(e => e.GradoNivel)
                .HasMaxLength(45)
                .HasColumnName("grado_nivel");
            entity.Property(e => e.GradoNombre)
                .HasMaxLength(45)
                .HasColumnName("grado_nombre");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabGradoActuals)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_grado_actual_no_nomina");
        });

        modelBuilder.Entity<ColabGradosTipo>(entity =>
        {
            entity.HasKey(e => e.GradoTipoId).HasName("PRIMARY");

            entity.ToTable("colab_grados_tipos");

            entity.Property(e => e.GradoTipoId)
                .ValueGeneratedNever()
                .HasColumnName("grado_tipo_id");
            entity.Property(e => e.GradoTipo).HasColumnName("grado_tipo");
        });

        modelBuilder.Entity<ColabIdioma>(entity =>
        {
            entity.HasKey(e => e.IdColabIdioma).HasName("PRIMARY");

            entity.ToTable("colab_idiomas");

            entity.HasIndex(e => e.NoNomina, "fk_idiomas_no_nomina_idx");

            entity.Property(e => e.IdColabIdioma).HasColumnName("id_colab_idioma");
            entity.Property(e => e.IdiomaDominio)
                .HasMaxLength(45)
                .HasColumnName("idioma_dominio");
            entity.Property(e => e.IdiomaNombre)
                .HasMaxLength(45)
                .HasColumnName("idioma_nombre");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.ColabIdiomas)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_idiomas_no_nomina");
        });

        modelBuilder.Entity<Discapacidade>(entity =>
        {
            entity.HasKey(e => e.DiscapacidadId).HasName("PRIMARY");

            entity.ToTable("discapacidades", tb => tb.HasComment("Discapacidades con concatenación en back"));

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.DiscapacidadId).HasColumnName("discapacidad_id");
            entity.Property(e => e.Discapacidades)
                .HasMaxLength(100)
                .HasColumnName("discapacidades");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.Discapacidades)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_discapidad_no_nomina");
        });

        modelBuilder.Entity<InfoColaborador>(entity =>
        {
            entity.HasKey(e => e.NoNomina).HasName("PRIMARY");

            entity.ToTable("info_colaborador");

            entity.Property(e => e.NoNomina)
                .ValueGeneratedNever()
                .HasColumnName("no_nomina");
            entity.Property(e => e.ColabAltaIsste)
                .HasColumnType("datetime")
                .HasColumnName("colab_alta_isste");
            entity.Property(e => e.ColabApMaterno)
                .HasMaxLength(45)
                .HasColumnName("colab_ap_materno");
            entity.Property(e => e.ColabApPaterno)
                .HasMaxLength(45)
                .HasColumnName("colab_ap_paterno");
            entity.Property(e => e.ColabAv)
                .HasMaxLength(45)
                .HasColumnName("colab_av");
            entity.Property(e => e.ColabCalle)
                .HasMaxLength(45)
                .HasColumnName("colab_calle");
            entity.Property(e => e.ColabColonia)
                .HasMaxLength(45)
                .HasColumnName("colab_colonia");
            entity.Property(e => e.ColabCp)
                .HasMaxLength(45)
                .HasColumnName("colab_cp");
            entity.Property(e => e.ColabCpSat)
                .HasMaxLength(45)
                .HasColumnName("colab_cp_sat");
            entity.Property(e => e.ColabCurp)
                .HasMaxLength(18)
                .HasColumnName("colab_curp");
            entity.Property(e => e.ColabDireccion)
                .HasMaxLength(255)
                .HasColumnName("colab_direccion");
            entity.Property(e => e.ColabEstCivil)
                .HasMaxLength(45)
                .HasColumnName("colab_est_civil");
            entity.Property(e => e.ColabEstado)
                .HasMaxLength(45)
                .HasColumnName("colab_estado");
            entity.Property(e => e.ColabFechaAlta)
                .HasColumnType("timestamp")
                .HasColumnName("colab_fecha_alta");
            entity.Property(e => e.ColabFechaBaja)
                .HasColumnType("timestamp")
                .HasColumnName("colab_fecha_baja");
            entity.Property(e => e.ColabFechaNac).HasColumnName("colab_fecha_nac");
            entity.Property(e => e.ColabFracc)
                .HasMaxLength(45)
                .HasColumnName("colab_fracc");
            entity.Property(e => e.ColabGobierno).HasColumnName("colab_gobierno");
            entity.Property(e => e.ColabLenguaIndigena)
                .HasMaxLength(45)
                .HasColumnName("colab_lengua_indigena");
            entity.Property(e => e.ColabLenguajeProgramacion)
                .HasMaxLength(100)
                .HasColumnName("colab_lenguaje_programacion");
            entity.Property(e => e.ColabLentes).HasColumnName("colab_lentes");
            entity.Property(e => e.ColabLote)
                .HasMaxLength(45)
                .HasColumnName("colab_lote");
            entity.Property(e => e.ColabManz)
                .HasMaxLength(45)
                .HasColumnName("colab_manz");
            entity.Property(e => e.ColabNombres)
                .HasMaxLength(45)
                .HasColumnName("colab_nombres");
            entity.Property(e => e.ColabNss)
                .HasMaxLength(45)
                .HasColumnName("colab_nss");
            entity.Property(e => e.ColabNumExt)
                .HasMaxLength(45)
                .HasColumnName("colab_num_ext");
            entity.Property(e => e.ColabNumInt)
                .HasMaxLength(45)
                .HasColumnName("colab_num_int");
            entity.Property(e => e.ColabPais).HasColumnName("colab_pais");
            entity.Property(e => e.ColabPaqueteria)
                .HasMaxLength(100)
                .HasColumnName("colab_paqueteria");
            entity.Property(e => e.ColabPuesto)
                .HasMaxLength(255)
                .HasColumnName("colab_puesto");
            entity.Property(e => e.ColabRfc)
                .HasMaxLength(13)
                .HasColumnName("colab_rfc");
            entity.Property(e => e.ColabSalario).HasColumnName("colab_salario");
            entity.Property(e => e.ColabSexo).HasColumnName("colab_sexo");
            entity.Property(e => e.ColabTipoSangre)
                .HasMaxLength(45)
                .HasColumnName("colab_tipo_sangre");
            entity.Property(e => e.ColabTrayectoriaAnios).HasColumnName("colab_trayectoria_anios");
        });

        modelBuilder.Entity<InformacionHijo>(entity =>
        {
            entity.HasKey(e => e.HijoCurp).HasName("PRIMARY");

            entity.ToTable("informacion_hijos");

            entity.HasIndex(e => e.NoNomina, "no_nomina_idx");

            entity.Property(e => e.HijoCurp)
                .HasMaxLength(45)
                .HasColumnName("hijo_curp");
            entity.Property(e => e.HijoFechaNac).HasColumnName("hijo_fecha_nac");
            entity.Property(e => e.HijoNombre)
                .HasMaxLength(45)
                .HasColumnName("hijo_nombre");
            entity.Property(e => e.HijoSexo)
                .HasMaxLength(45)
                .HasColumnName("hijo_sexo");
            entity.Property(e => e.NoNomina).HasColumnName("no_nomina");

            entity.HasOne(d => d.NoNominaNavigation).WithMany(p => p.InformacionHijos)
                .HasForeignKey(d => d.NoNomina)
                .HasConstraintName("fk_hijo_no_nomina");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.PermisosId).HasName("PRIMARY");

            entity.ToTable("permisos");

            entity.Property(e => e.PermisosId)
                .ValueGeneratedNever()
                .HasColumnName("permisos_id");
            entity.Property(e => e.PermisosTipo)
                .HasMaxLength(45)
                .HasColumnName("permisos_tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
