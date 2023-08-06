using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AssetGuard_Project.Models;

namespace AssetGuard_Project.Models;

public partial class AssetGuardDbContext : DbContext
{
    public AssetGuardDbContext()
    {
    }

    public AssetGuardDbContext(DbContextOptions<AssetGuardDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivosFijo> ActivosFijos { get; set; }

    public virtual DbSet<CalculoDepreciacion> CalculoDepreciacions { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<TiposActivo> TiposActivos { get; set; }
    public virtual DbSet<EnvioContabilidad> EnvioContabilidad { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=AssetGuardDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivosFijo>(entity =>
        {
            entity.HasKey(e => e.IdAf).HasName("PK__ActivosF__B773A0C2A38A4F45");

            entity.Property(e => e.IdAf).HasColumnName("IdAF");
            entity.Property(e => e.DepartamentoAf).HasColumnName("DepartamentoAF");
            entity.Property(e => e.DepreciacionAcumuladaAf)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DepreciacionAcumuladaAF");
            entity.Property(e => e.DescripcionAf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DescripcionAF");
            entity.Property(e => e.FechaRegistroAf)
                .HasColumnType("date")
                .HasColumnName("FechaRegistroAF");
            entity.Property(e => e.TipoActivoAf).HasColumnName("TipoActivoAF");
            entity.Property(e => e.ValorCompraAf)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ValorCompraAF");

            entity.HasOne(d => d.DepartamentoAfNavigation).WithMany(p => p.ActivosFijos)
                .HasForeignKey(d => d.DepartamentoAf)
                .HasConstraintName("FK__ActivosFi__Depar__3E52440B");

            entity.HasOne(d => d.TipoActivoAfNavigation).WithMany(p => p.ActivosFijos)
                .HasForeignKey(d => d.TipoActivoAf)
                .HasConstraintName("FK__ActivosFi__TipoA__3F466844");
        });

        modelBuilder.Entity<CalculoDepreciacion>(entity =>
        {
            entity.HasKey(e => e.IdCd).HasName("PK__CalculoD__B773908796FD6285");

            entity.ToTable("CalculoDepreciacion");

            entity.Property(e => e.IdCd).HasColumnName("IdCD");
            entity.Property(e => e.ActivoFijoCd).HasColumnName("ActivoFijoCD");
            entity.Property(e => e.AnoProcesoCd)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("AnoProcesoCD");
            entity.Property(e => e.DepreciacionAcumuladaCd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DepreciacionAcumuladaCD");
            entity.Property(e => e.FechaProcesoCd)
                .HasColumnType("date")
                .HasColumnName("FechaProcesoCD");
            entity.Property(e => e.MesProcesoCd)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("MesProcesoCD");
            entity.Property(e => e.MontoDepreciadoCd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MontoDepreciadoCD");

            entity.HasOne(d => d.ActivoFijoCdNavigation)
                .WithMany(p => p.CalculoDepreciacions)
                .HasForeignKey(d => d.ActivoFijoCd)
                .HasConstraintName("FK__CalculoDe__Activ__4222D4EF");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DF01BE3B3");

            entity.Property(e => e.DescripcionDepartamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EstadoDepartamento)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E7C1BBA10");

            entity.ToTable("Empleado");

            entity.Property(e => e.CedulaEmpleado)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.EstadoEmpleado)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngresoEmpleado).HasColumnType("date");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoPersonaEmpleado)
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.HasOne(d => d.DepartamentoEmpleadoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DepartamentoEmpleado)
                .HasConstraintName("FK__Empleado__Depart__3B75D760");
        });

        modelBuilder.Entity<TiposActivo>(entity =>
        {
            entity.HasKey(e => e.IdTa).HasName("PK__TiposAct__B7701AB7A654C049");

            entity.Property(e => e.IdTa).HasColumnName("IdTA");
            entity.Property(e => e.CuentaContableCompraTa).HasColumnName("CuentaContableCompraTA");
            entity.Property(e => e.CuentaContableDepreciacionTa).HasColumnName("CuentaContableDepreciacionTA");
            entity.Property(e => e.DescripcionTa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DescripcionTA");
            entity.Property(e => e.EstadoTa)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("EstadoTA");
        });

        modelBuilder.Entity<EnvioContabilidad>(entity =>
        {
            entity.HasKey(e => e.IdEC).HasName("PK__EnvioCon__B7738042C2B8E81E");

            entity.ToTable("EnvioContabilidad");

            entity.Property(e => e.IdEC).HasColumnName("IdEC");

            entity.Property(e => e.CuentaCR).HasColumnName("CuentaCR");

            entity.Property(e => e.CuentaDB).HasColumnName("CuentaDB");

            entity.Property(e => e.DescripcionEC)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DescripcionEC");

            entity.Property(e => e.MontoEnvioContabilidad).HasColumnName("MontoEnvioContabilidad");

            entity.HasOne(d => d.MontoEnvioContabilidadNavigation)
                .WithMany(p => p.EnvioContabilidades)
                .HasForeignKey(d => d.MontoEnvioContabilidad)
                .HasConstraintName("FK__EnvioCont__Monto__5CD6CB2B");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
