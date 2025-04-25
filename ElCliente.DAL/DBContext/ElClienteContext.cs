using System;
using System.Collections.Generic;
using ElCliente.Modelos.modelos;
using Microsoft.EntityFrameworkCore;

namespace ElCliente.DAL.DBContext
{
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
                      .HasMaxLength(20)  // Ajustado a 20 según tu SQL
                      .IsUnicode(false)
                      .HasColumnName("tr_accion");
                entity.Property(e => e.Fecha)
                      .HasColumnName("tr_fechatransaccion")
                      .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__cliente__3213E83F84CE2ADC");
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                    .HasColumnName("cli_id")
                    .ValueGeneratedOnAdd();


                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cli_nombre");  // Ajustado

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cli_apellidos");  // Ajustado

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cli_ciudad");  // Ajustado

                entity.Property(e => e.CliMonto)
                    .HasColumnName("cli_monto")
                     .HasColumnType("money")
                    .HasDefaultValueSql("500000");// Ajustado
                   
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__producto__3213E83F147F0DE6");
                entity.ToTable("producto");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("prod_id");  // Ajustado

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("prod_nombre");  // Ajustado

                entity.Property(e => e.TipoProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("prod_tipoproducto");  // Ajustado

                entity.Property(e => e.ProdMontoMinimo)
                    .HasColumnName("prod_monto_minimo")  // Ajustado
                    .HasColumnType("money");

                entity.HasMany(d => d.IdClientes).WithMany(p => p.IdProductos)
                    .UsingEntity<Dictionary<string, object>>(
                        "Inscripcion",
                        r => r.HasOne<Cliente>().WithMany()
                            .HasForeignKey("ins_idcliente")  // Ajustado
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("FK__inscripci__idCli__3E52440B"),
                        l => l.HasOne<Producto>().WithMany()
                            .HasForeignKey("ins_idproducto")  // Ajustado
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("FK__inscripci__idPro__3D5E1FD2"),
                        j =>
                        {
                            j.HasKey("ins_idproducto", "ins_idcliente")  // Ajustado
                             .HasName("PK__inscripc__FF71E44CCF897EC5");
                            j.ToTable("inscripcion");
                            j.IndexerProperty<int>("ins_idproducto").HasColumnName("ins_idproducto");  // Ajustado
                            j.IndexerProperty<int>("ins_idcliente").HasColumnName("ins_idcliente");  // Ajustado
                        });
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__sucursal__3213E83F8482DEB6");
                entity.ToTable("sucursal");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("suc_id");  // Ajustado

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("suc_nombre");  // Ajustado

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("suc_ciudad");  // Ajustado

                entity.HasMany(d => d.IdProductos).WithMany(p => p.IdSucursals)
                    .UsingEntity<Dictionary<string, object>>(
                        "Disponibilidad",
                        r => r.HasOne<Producto>().WithMany()
                            .HasForeignKey("dis_idproducto")  // Ajustado
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__disponibi__idPro__4222D4EF"),
                        l => l.HasOne<Sucursal>().WithMany()
                            .HasForeignKey("dis_idsucursal")  // Ajustado
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__disponibi__idSuc__412EB0B6"),
                        j =>
                        {
                            j.HasKey("dis_idsucursal", "dis_idproducto")  // Ajustado
                             .HasName("PK__disponib__C778235FEDABF1AB");
                            j.ToTable("disponibilidad");
                            j.IndexerProperty<int>("dis_idsucursal").HasColumnName("dis_idsucursal");  // Ajustado
                            j.IndexerProperty<int>("dis_idproducto").HasColumnName("dis_idproducto");  // Ajustado
                        });
            });

            modelBuilder.Entity<Visitan>(entity =>
            {
                entity.HasKey(e => new { e.IdSucursal, e.IdCliente }).HasName("PK__visitan__0F822C3274679004");
                entity.ToTable("visitan");

                entity.Property(e => e.IdSucursal).HasColumnName("vis_idsucursal");  // Ajustado
                entity.Property(e => e.IdCliente).HasColumnName("vis_idcliente");  // Ajustado
                entity.Property(e => e.FechaVisita).HasColumnName("vis_fechavisita");  // Ajustado

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
}