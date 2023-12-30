using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Usuarios.Models;

public partial class ClientesContext : DbContext
{
    public ClientesContext()
    {
    }

    public ClientesContext(DbContextOptions<ClientesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<DatosSalariale> DatosSalariales { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        if (!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("server=DESKTOP-0HTGN4T; database=Clientes; integrated security=true;TrustServerCertificate=true");
        }


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CodigoCargo).HasName("PK__Cargos__28AC9291746AECDC");

            entity.Property(e => e.CodigoCargo).ValueGeneratedNever();
            entity.Property(e => e.NombreCargo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DatosSalariale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DatosSal__3214EC2733A78629");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.CedulaEmpleadoNavigation).WithMany(p => p.DatosSalariales)
                .HasForeignKey(d => d.CedulaEmpleado)
                .HasConstraintName("FK__DatosSala__Cedul__4222D4EF");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PK__Empleado__B4ADFE39A0F3C34C");

            entity.Property(e => e.Cedula).ValueGeneratedNever();
            entity.Property(e => e.Apellido1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Apellido2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoCargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodigoCargo)
                .HasConstraintName("FK__Empleados__Codig__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
