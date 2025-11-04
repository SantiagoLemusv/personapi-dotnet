using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace personapi_dotnet.Models.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudio> Estudios { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Profesion> Profesions { get; set; }

    public virtual DbSet<Telefono> Telefonos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
   //     => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=persona_db;User Id=sa;Password=YourStrong!Passw0rd1;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudio>(entity =>
        {
            entity.HasKey(e => e.IdEstudio).HasName("PK__estudios__CE33B95EAF3CCD74");

            entity.ToTable("estudios");

            entity.Property(e => e.IdEstudio).HasColumnName("id_estudio");
            entity.Property(e => e.CcPer).HasColumnName("cc_per");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Univer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("univer");

            entity.HasOne(d => d.CcPerNavigation).WithMany(p => p.Estudios)
                .HasForeignKey(d => d.CcPer)
                .HasConstraintName("fk_estudio_persona");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Cc).HasName("PK__persona__3213666D5F813E69");

            entity.ToTable("persona");

            entity.Property(e => e.Cc)
                .ValueGeneratedNever()
                .HasColumnName("cc");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Profesion>(entity =>
        {
            entity.HasKey(e => e.IdProf).HasName("PK__profesio__0DA3484DCCF21E1A");

            entity.ToTable("profesion");

            entity.Property(e => e.IdProf).HasColumnName("id_prof");
            entity.Property(e => e.Des)
                .HasColumnType("text")
                .HasColumnName("des");
            entity.Property(e => e.Nom)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Telefono>(entity =>
        {
            entity.HasKey(e => e.IdTelefono).HasName("PK__telefono__28CD6802DE60A3BB");

            entity.ToTable("telefono");

            entity.Property(e => e.IdTelefono).HasColumnName("id_telefono");
            entity.Property(e => e.DuenioCc).HasColumnName("duenio_cc");
            entity.Property(e => e.Num)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("num");
            entity.Property(e => e.Oper)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("oper");

            entity.HasOne(d => d.DuenioCcNavigation).WithMany(p => p.Telefonos)
                .HasForeignKey(d => d.DuenioCc)
                .HasConstraintName("fk_telefono_persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
