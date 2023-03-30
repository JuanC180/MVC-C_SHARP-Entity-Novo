using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Novotic.Models
{
    public partial class novoContext : DbContext
    {
        public novoContext()
        {
        }

        public novoContext(DbContextOptions<novoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cartera> Carteras { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TipoRol> TipoRols { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=novo;integrated security=True; TrustServerCertificate=True");
                */
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartera>(entity =>
            {
                entity.HasKey(e => e.CodigoCartera)
                    .HasName("PK__cartera__78C7266B20ACB614");

                entity.ToTable("cartera");

                entity.Property(e => e.CodigoCartera).HasColumnName("codigo_cartera");

                entity.Property(e => e.CodigoVenta).HasColumnName("codigo_venta");

                entity.Property(e => e.CoutaRestanteCartera).HasColumnName("couta_restante_cartera");

                entity.Property(e => e.EstadoCartera).HasColumnName("estado_cartera");

                entity.Property(e => e.FechaCartera)
                    .HasColumnType("date")
                    .HasColumnName("fecha_cartera");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.PendienteCartera)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("pendiente_cartera");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__677F38F57FCD367C");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.ApellidoCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("apellido_cliente");

                entity.Property(e => e.CamaraComercioCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("camara_comercio_cliente");

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("cedula_cliente");

                entity.Property(e => e.CiudadCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ciudad_cliente");

                entity.Property(e => e.DepartamentoCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("departamento_cliente");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("direccion_cliente");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("email_cliente");

                entity.Property(e => e.EstadoCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("estado_cliente");

                entity.Property(e => e.NitRutCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nit_rut_cliente");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cliente");

                entity.Property(e => e.PasswordCliente)
                    .HasColumnType("text")
                    .HasColumnName("password_cliente");

                entity.Property(e => e.RolCliente).HasColumnName("rol_cliente");

                entity.Property(e => e.TelefonoCliente)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono_cliente");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.HasKey(e => e.CodigoDetalleVenta)
                    .HasName("PK__detalle___647F5689E68B4531");

                entity.ToTable("detalle_venta");

                entity.Property(e => e.CodigoDetalleVenta).HasColumnName("codigo_detalle_venta");

                entity.Property(e => e.CantidadDetalleVenta)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cantidad_detalle_venta");

                entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");

                entity.Property(e => e.CodigoVenta).HasColumnName("codigo_venta");

                entity.Property(e => e.PrecioUnitarioDetalleVenta)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio_unitario_detalle_venta");

                entity.Property(e => e.SubtotalDetalleVenta)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("subtotal_detalle_venta");

                entity.Property(e => e.ValorTotalDetalleVenta)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valor_total_detalle_venta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto)
                    .HasName("PK__producto__105107A92C2FA8C0");

                entity.ToTable("producto");

                entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");

                entity.Property(e => e.DescripcionProducto)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_producto");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Imagen)
                    .HasColumnType("image")
                    .HasColumnName("imagen");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto");

                entity.Property(e => e.PrecioPrducto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio_prducto");
            });

            modelBuilder.Entity<TipoRol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__tipo_rol__6ABCB5E0C2D13F0D");

                entity.ToTable("tipo_rol");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.EstadoRol).HasColumnName("estado_rol");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.CodigoVenta)
                    .HasName("PK__venta__064A4E43113894CD");

                entity.ToTable("venta");

                entity.Property(e => e.CodigoVenta).HasColumnName("codigo_venta");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("fecha_venta");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.ValorTotalVenta)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valor_total_venta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
