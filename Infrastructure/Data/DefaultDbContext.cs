using System;
using System.Collections.Generic;
using PruebaTecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Infraestructure.Data;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Productos> Producto { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local)\\MSSQLSERVER01;Database=afpCrecer;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Productos>(b =>
        {
            b.ToTable("Productos");             // nombre tabla
            b.HasKey(p => p.ProductoId);                // PK

            b.Property(p => p.Nombre)
             .IsRequired()
             .HasMaxLength(100);

            b.Property(p => p.Descripcion)
             .HasMaxLength(500);

            // Precisión explícita para evitar warnings
            b.Property(p => p.Precio)
             .HasPrecision(18, 4);

            b.Property(p => p.PrecioDescuento)
             .HasPrecision(18, 4);
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
