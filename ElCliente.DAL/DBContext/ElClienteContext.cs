using System;
using System.Collections.Generic;
using ElCliente.Modelos.modelos;
using Microsoft.EntityFrameworkCore;

namespace ElCliente.DAL.DBContext;

public partial class ElClienteContext : DbContext
{
    public ElClienteContext()
    {
    }

    public ElClienteContext(DbContextOptions<ElClienteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Visitan> Visitans { get; set; }
    public virtual DbSet<TransaccionInscripcion> TransaccionesInscripcion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    var transacciones = new List<TransaccionInscripcion>();

    //    foreach (var entry in ChangeTracker.Entries<TransaccionInscripcion>())
    //    {
    //        if (entry.State == EntityState.Added)
    //        {
    //            transacciones.Add(new TransaccionInscripcion
    //            {
    //                Tr_IdCliente = entry.Entity.Tr_IdCliente,
    //                Tr_IdProducto = entry.Entity.Tr_IdProducto,
    //                Accion = "INSERT"
    //            });
    //        }
    //        else if (entry.State == EntityState.Deleted)
    //        {
    //            transacciones.Add(new TransaccionInscripcion
    //            {
    //                Tr_IdCliente = entry.Entity.Tr_IdCliente,
    //                Tr_IdProducto = entry.Entity.Tr_IdProducto,
    //                Accion = "DELETE"
    //            });
    //        }
    //    }

    //    // Guardar primero los cambios normales
    //    var result = await base.SaveChangesAsync(cancellationToken);

    //    // Luego guardar las transacciones
    //    if (transacciones.Any())
    //    {
    //        TransaccionesInscripcion.AddRange(transacciones);
    //        await base.SaveChangesAsync(cancellationToken);
    //    }

    //    return result;
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<TransaccionInscripcion>(entity =>
        {
            entity.ToTable("transacciones_inscripcion");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("tr_id");
            entity.Property(e => e.Tr_IdCliente).HasColumnName("tr_idcliente");
            entity.Property(e => e.Tr_IdProducto).HasColumnName("tr_idproducto");
            entity.Property(e => e.Accion)
                  .HasMaxLength(10)
                  .IsUnicode(false)
                  .HasColumnName("accion");
            entity.Property(e => e.Fecha)
                  .HasColumnName("fechaTransaccion")
                  .HasDefaultValueSql("GETDATE()");
        });
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cliente__3213E83F84CE2ADC");

            entity.ToTable("cliente");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.CliMonto).HasColumnName("cli_monto").HasColumnType("money");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83F147F0DE6");

            entity.ToTable("producto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoProducto");
            entity.Property(e => e.ProdMontoMinimo).HasColumnName("prod_monto_minimo").HasColumnType("money");

            entity.HasMany(d => d.IdClientes).WithMany(p => p.IdProductos)
                .UsingEntity<Dictionary<string, object>>(
                    "Inscripcion",
                    r => r.HasOne<Cliente>().WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK__inscripci__idCli__3E52440B"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK__inscripci__idPro__3D5E1FD2"),
                    j =>
                    {
                        j.HasKey("IdProducto", "IdCliente").HasName("PK__inscripc__FF71E44CCF897EC5");
                        j.ToTable("inscripcion");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("idProducto");
                        j.IndexerProperty<int>("IdCliente").HasColumnName("idCliente");
                    });
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sucursal__3213E83F8482DEB6");

            entity.ToTable("sucursal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasMany(d => d.IdProductos).WithMany(p => p.IdSucursals)
                .UsingEntity<Dictionary<string, object>>(
                    "Disponibilidad",
                    r => r.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__disponibi__idPro__4222D4EF"),
                    l => l.HasOne<Sucursal>().WithMany()
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__disponibi__idSuc__412EB0B6"),
                    j =>
                    {
                        j.HasKey("IdSucursal", "IdProducto").HasName("PK__disponib__C778235FEDABF1AB");
                        j.ToTable("disponibilidad");
                        j.IndexerProperty<int>("IdSucursal").HasColumnName("idSucursal");
                        j.IndexerProperty<int>("IdProducto").HasColumnName("idProducto");
                    });
        });

        modelBuilder.Entity<Visitan>(entity =>
        {
            entity.HasKey(e => new { e.IdSucursal, e.IdCliente }).HasName("PK__visitan__0F822C3274679004");

            entity.ToTable("visitan");

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.FechaVisita).HasColumnName("fechaVisita");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Visitans)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__visitan__idClien__45F365D3");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Visitans)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__visitan__idSucur__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
