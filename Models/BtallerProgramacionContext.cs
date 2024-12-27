using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClaseNosePeroClase.Models;

public partial class BtallerProgramacionContext : DbContext
{
    public BtallerProgramacionContext()
    {
    }

    public BtallerProgramacionContext(DbContextOptions<BtallerProgramacionContext> options)
        : base(options)
    {
    }

    public DbSet<Contacto> Contactos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Rut).HasName("PK__Contacto__CAF33259BFDA79DD");

            entity.Property(e => e.Rut)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("RUT");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
