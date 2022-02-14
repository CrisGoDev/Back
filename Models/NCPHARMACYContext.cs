using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NCPHARMACY.Models
{
    public partial class NCPHARMACYContext : DbContext
    {
        public NCPHARMACYContext()
        {
        }

        public NCPHARMACYContext(DbContextOptions<NCPHARMACYContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<DetalleDeVenta> DetalleDeVentas { get; set; }
        public virtual DbSet<DetalleLineaDeProduccione> DetalleLineaDeProducciones { get; set; }
        public virtual DbSet<DetalleProyecto> DetalleProyectos { get; set; }
        public virtual DbSet<DetalleProyectoCosto> DetalleProyectoCostos { get; set; }
        public virtual DbSet<DetalleProyectoGasto> DetalleProyectoGastos { get; set; }
        public virtual DbSet<DetallesCompra> DetallesCompras { get; set; }
        public virtual DbSet<DevolucionesCompra> DevolucionesCompras { get; set; }
        public virtual DbSet<DevolucionesVenta> DevolucionesVentas { get; set; }
        public virtual DbSet<Distribuidora> Distribuidoras { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoProyecto> EstadoProyectos { get; set; }
        public virtual DbSet<Insumo> Insumos { get; set; }
        public virtual DbSet<LineaDeProduccione> LineaDeProducciones { get; set; }
        public virtual DbSet<PeopleInfo> PeopleInfos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<PuestosDeTrabajo> PuestosDeTrabajos { get; set; }
        public virtual DbSet<TipoAmotizacione> TipoAmotizaciones { get; set; }
        public virtual DbSet<TipoCrecimiento> TipoCrecimientos { get; set; }
        public virtual DbSet<TipoDepreciacione> TipoDepreciaciones { get; set; }
        public virtual DbSet<TipoEstadoEmpleado> TipoEstadoEmpleados { get; set; }
        public virtual DbSet<TipoEstadoProduccion> TipoEstadoProduccions { get; set; }
        public virtual DbSet<TipoEstadoVenta> TipoEstadoVentas { get; set; }
        public virtual DbSet<TipoEstadosCompra> TipoEstadosCompras { get; set; }
        public virtual DbSet<TiposPeriodo> TiposPeriodos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NJNBG6M;Database=NCPHARMACY;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compras__661E0ED0EA0AECE3");

                entity.Property(e => e.IdCompra).HasColumnName("Id_Compra");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");

                entity.Property(e => e.IdTipoEstadoCrompa).HasColumnName("Id_TipoEstadoCrompa");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Compras__Id_Empl__4D94879B");

                entity.HasOne(d => d.IdTipoEstadoCrompaNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdTipoEstadoCrompa)
                    .HasConstraintName("FK__Compras__Id_Tipo__4E88ABD4");
            });

            modelBuilder.Entity<DetalleDeVenta>(entity =>
            {
                entity.HasKey(e => e.IdDetalleDeVentas)
                    .HasName("PK__DetalleD__32BBF74ACE2C839F");

                entity.Property(e => e.IdDetalleDeVentas).HasColumnName("Id_DetalleDeVentas");

                entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

                entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleDeVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__DetalleDe__Id_Pr__6A30C649");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleDeVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK__DetalleDe__Id_Ve__693CA210");
            });

            modelBuilder.Entity<DetalleLineaDeProduccione>(entity =>
            {
                entity.HasKey(e => e.IdDetalleLineaDeProduccion)
                    .HasName("PK__DetalleL__A86917450171ED18");

                entity.Property(e => e.IdDetalleLineaDeProduccion).HasColumnName("Id_DetalleLineaDeProduccion");

                entity.Property(e => e.IdInsumo).HasColumnName("Id_Insumo");

                entity.Property(e => e.IdLineaDeProduccion).HasColumnName("Id_LineaDeProduccion");

                entity.HasOne(d => d.IdInsumoNavigation)
                    .WithMany(p => p.DetalleLineaDeProducciones)
                    .HasForeignKey(d => d.IdInsumo)
                    .HasConstraintName("FK__DetalleLi__Id_In__5DCAEF64");

                entity.HasOne(d => d.IdLineaDeProduccionNavigation)
                    .WithMany(p => p.DetalleLineaDeProducciones)
                    .HasForeignKey(d => d.IdLineaDeProduccion)
                    .HasConstraintName("FK__DetalleLi__Id_Li__5CD6CB2B");
            });

            modelBuilder.Entity<DetalleProyecto>(entity =>
            {
                entity.HasKey(e => e.IdDetalleProyecto)
                    .HasName("PK__DetalleP__D0D15A85B54FC4CB");

                entity.ToTable("DetalleProyecto");

                entity.Property(e => e.IdDetalleProyecto).HasColumnName("Id_DetalleProyecto");

                entity.Property(e => e.IdProyecto).HasColumnName("Id_Proyecto");

                entity.Property(e => e.IdTipoAmortizacion).HasColumnName("Id_TipoAmortizacion");

                entity.Property(e => e.IdTipoCrecimientoIngresos).HasColumnName("Id_TipoCrecimientoIngresos");

                entity.Property(e => e.IdTipoDepreciacion).HasColumnName("Id_TipoDepreciacion");

                entity.Property(e => e.IdTipoPeridos).HasColumnName("Id_TipoPeridos");

                entity.Property(e => e.Tmarinversionista).HasColumnName("TMARInversionista");

                entity.Property(e => e.ValorMaquinariaYequipo).HasColumnName("ValorMaquinariaYEquipo");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.DetalleProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK__DetallePr__Id_Pr__30F848ED");

                entity.HasOne(d => d.IdTipoAmortizacionNavigation)
                    .WithMany(p => p.DetalleProyectos)
                    .HasForeignKey(d => d.IdTipoAmortizacion)
                    .HasConstraintName("FK__DetallePr__Id_Ti__33D4B598");

                entity.HasOne(d => d.IdTipoCrecimientoIngresosNavigation)
                    .WithMany(p => p.DetalleProyectos)
                    .HasForeignKey(d => d.IdTipoCrecimientoIngresos)
                    .HasConstraintName("FK__DetallePr__Id_Ti__34C8D9D1");

                entity.HasOne(d => d.IdTipoDepreciacionNavigation)
                    .WithMany(p => p.DetalleProyectos)
                    .HasForeignKey(d => d.IdTipoDepreciacion)
                    .HasConstraintName("FK__DetallePr__Id_Ti__32E0915F");

                entity.HasOne(d => d.IdTipoPeridosNavigation)
                    .WithMany(p => p.DetalleProyectos)
                    .HasForeignKey(d => d.IdTipoPeridos)
                    .HasConstraintName("FK__DetallePr__Id_Ti__31EC6D26");
            });

            modelBuilder.Entity<DetalleProyectoCosto>(entity =>
            {
                entity.HasKey(e => e.IdTipoCosto)
                    .HasName("PK__DetalleP__48812D1EE89F0D85");

                entity.Property(e => e.IdTipoCosto).HasColumnName("Id_TipoCosto");

                entity.Property(e => e.IdDetalleProyecto).HasColumnName("Id_DetalleProyecto");

                entity.Property(e => e.NombreCosto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDetalleProyectoNavigation)
                    .WithMany(p => p.DetalleProyectoCostos)
                    .HasForeignKey(d => d.IdDetalleProyecto)
                    .HasConstraintName("FK__DetallePr__Id_De__37A5467C");

                entity.HasOne(d => d.TipoCrecimientoNavigation)
                    .WithMany(p => p.DetalleProyectoCostos)
                    .HasForeignKey(d => d.TipoCrecimiento)
                    .HasConstraintName("FK__DetallePr__TipoC__38996AB5");
            });

            modelBuilder.Entity<DetalleProyectoGasto>(entity =>
            {
                entity.HasKey(e => e.IdTipoGasto)
                    .HasName("PK__DetalleP__4A6DE8826CE2F6F0");

                entity.Property(e => e.IdTipoGasto).HasColumnName("Id_TipoGasto");

                entity.Property(e => e.IdDetalleProyecto).HasColumnName("Id_DetalleProyecto");

                entity.Property(e => e.NombreGasto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDetalleProyectoNavigation)
                    .WithMany(p => p.DetalleProyectoGastos)
                    .HasForeignKey(d => d.IdDetalleProyecto)
                    .HasConstraintName("FK__DetallePr__Id_De__3B75D760");

                entity.HasOne(d => d.TipoCrecimientoNavigation)
                    .WithMany(p => p.DetalleProyectoGastos)
                    .HasForeignKey(d => d.TipoCrecimiento)
                    .HasConstraintName("FK__DetallePr__TipoC__3C69FB99");
            });

            modelBuilder.Entity<DetallesCompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PK__Detalles__C938BE991CE11407");

                entity.ToTable("DetallesCompra");

                entity.Property(e => e.IdDetalleCompra).HasColumnName("Id_DetalleCompra");

                entity.Property(e => e.IdCompra).HasColumnName("Id_Compra");

                entity.Property(e => e.IdInsumo).HasColumnName("Id_Insumo");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetallesCompras)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK__DetallesC__Id_Co__5165187F");

                entity.HasOne(d => d.IdInsumoNavigation)
                    .WithMany(p => p.DetallesCompras)
                    .HasForeignKey(d => d.IdInsumo)
                    .HasConstraintName("FK__DetallesC__Id_In__52593CB8");
            });

            modelBuilder.Entity<DevolucionesCompra>(entity =>
            {
                entity.HasKey(e => e.IdDevolucionesCompra)
                    .HasName("PK__Devoluci__C600E218844406C0");

                entity.Property(e => e.IdDevolucionesCompra).HasColumnName("Id_DevolucionesCompra");

                entity.Property(e => e.IdDetalleCompra).HasColumnName("Id_DetalleCompra");

                entity.HasOne(d => d.IdDetalleCompraNavigation)
                    .WithMany(p => p.DevolucionesCompras)
                    .HasForeignKey(d => d.IdDetalleCompra)
                    .HasConstraintName("FK__Devolucio__Id_De__6FE99F9F");
            });

            modelBuilder.Entity<DevolucionesVenta>(entity =>
            {
                entity.HasKey(e => e.IdDevolucionVenta)
                    .HasName("PK__Devoluci__CE26F4A03C4E6A0E");

                entity.Property(e => e.IdDevolucionVenta).HasColumnName("Id_DevolucionVenta");

                entity.Property(e => e.IdDetalleVenta).HasColumnName("Id_DetalleVenta");

                entity.HasOne(d => d.IdDetalleVentaNavigation)
                    .WithMany(p => p.DevolucionesVenta)
                    .HasForeignKey(d => d.IdDetalleVenta)
                    .HasConstraintName("FK__Devolucio__Id_De__6D0D32F4");
            });

            modelBuilder.Entity<Distribuidora>(entity =>
            {
                entity.HasKey(e => e.IdDistribuidora)
                    .HasName("PK__Distribu__FBE3BD422EEB6224");

                entity.Property(e => e.IdDistribuidora).HasColumnName("Id_Distribuidora");

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__7405622303D17C0C");

                entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdPuestoTrabajo).HasColumnName("Id_PuestoTrabajo");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK__Empleados__Estad__440B1D61");

                entity.HasOne(d => d.IdPuestoTrabajoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdPuestoTrabajo)
                    .HasConstraintName("FK__Empleados__Id_Pu__4316F928");
            });

            modelBuilder.Entity<EstadoProyecto>(entity =>
            {
                entity.HasKey(e => e.IdEstadoProyecto)
                    .HasName("PK__EstadoPr__43449E2D85724FA5");

                entity.ToTable("EstadoProyecto");

                entity.Property(e => e.IdEstadoProyecto).HasColumnName("Id_EstadoProyecto");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.HasKey(e => e.IdInsumo)
                    .HasName("PK__Insumos__02514E868795BAE3");

                entity.Property(e => e.IdInsumo).HasColumnName("Id_Insumo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Insumos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK__Insumos__Id_Prov__48CFD27E");
            });

            modelBuilder.Entity<LineaDeProduccione>(entity =>
            {
                entity.HasKey(e => e.IdLineaDeProduccion)
                    .HasName("PK__LineaDeP__3F4BB66595321A02");

                entity.Property(e => e.IdLineaDeProduccion).HasColumnName("Id_LineaDeProduccion");

                entity.Property(e => e.DescripcionLinea)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.LineaDeProducciones)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__LineaDePr__Id_Pr__59063A47");

                entity.HasOne(d => d.IdTipoEstadoProduccionNavigation)
                    .WithMany(p => p.LineaDeProducciones)
                    .HasForeignKey(d => d.IdTipoEstadoProduccion)
                    .HasConstraintName("FK__LineaDePr__IdTip__59FA5E80");
            });

            modelBuilder.Entity<PeopleInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("people_info");

                entity.Property(e => e.Condition).HasColumnName("condition");

                entity.Property(e => e.DrugName).HasColumnName("drugName");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UniqueId).HasColumnName("uniqueID");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__2085A9CFE7DA9829");

                entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__477B858E4097713A");

                entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PK__Proyecto__695276663140A582");

                entity.Property(e => e.IdProyecto).HasColumnName("Id_Proyecto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK__Proyectos__Estad__286302EC");
            });

            modelBuilder.Entity<PuestosDeTrabajo>(entity =>
            {
                entity.HasKey(e => e.IdPuestoDeTrabajo)
                    .HasName("PK__PuestosD__D922E2416DCF81E3");

                entity.ToTable("PuestosDeTrabajo");

                entity.Property(e => e.IdPuestoDeTrabajo).HasColumnName("Id_PuestoDeTrabajo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoAmotizacione>(entity =>
            {
                entity.HasKey(e => e.IdTipoAmortizacion)
                    .HasName("PK__TipoAmot__D765E97C8955AD24");

                entity.Property(e => e.IdTipoAmortizacion).HasColumnName("Id_TipoAmortizacion");

                entity.Property(e => e.TipoAmortizacion)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCrecimiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoCrecimiento)
                    .HasName("PK__TipoCrec__33F9DB91DD757326");

                entity.ToTable("TipoCrecimiento");

                entity.Property(e => e.IdTipoCrecimiento).HasColumnName("Id_TipoCrecimiento");

                entity.Property(e => e.TipoCrecimiento1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoCrecimiento");
            });

            modelBuilder.Entity<TipoDepreciacione>(entity =>
            {
                entity.HasKey(e => e.IdTipoDepreciacion)
                    .HasName("PK__TipoDepr__73F8E78E3B06ADBA");

                entity.Property(e => e.IdTipoDepreciacion).HasColumnName("Id_TipoDepreciacion");

                entity.Property(e => e.TipoDepreciacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEstadoEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstadoEmpleado)
                    .HasName("PK__TipoEsta__B95778C7FCCCAC21");

                entity.ToTable("TipoEstadoEmpleado");

                entity.Property(e => e.IdTipoEstadoEmpleado).HasColumnName("Id_TipoEstadoEmpleado");

                entity.Property(e => e.TipoEstadoEmpleado1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TipoEstadoEmpleado");
            });

            modelBuilder.Entity<TipoEstadoProduccion>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstadoProduccion)
                    .HasName("PK__TipoEsta__BF14E19EB8FE42D0");

                entity.ToTable("TipoEstadoProduccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEstadoVenta>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstadoVentas)
                    .HasName("PK__TipoEsta__3C3B91863CADA727");

                entity.Property(e => e.IdTipoEstadoVentas).HasColumnName("Id_TipoEstadoVentas");

                entity.Property(e => e.TipoEstadoVenta1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TipoEstadoVenta");
            });

            modelBuilder.Entity<TipoEstadosCompra>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstadoCompra)
                    .HasName("PK__TipoEsta__89D37FDFE6EDF374");

                entity.ToTable("TipoEstadosCompra");

                entity.Property(e => e.IdTipoEstadoCompra).HasColumnName("Id_TipoEstadoCompra");

                entity.Property(e => e.TipoEstadosCompra1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TipoEstadosCompra");
            });

            modelBuilder.Entity<TiposPeriodo>(entity =>
            {
                entity.HasKey(e => e.IdTipoPeridos)
                    .HasName("PK__TiposPer__8CC72F5E22C31290");

                entity.Property(e => e.IdTipoPeridos).HasColumnName("Id_TipoPeridos");

                entity.Property(e => e.TipoPerido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__63C76BE2E1DF1E71");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Ventas__B3C9EABDBAA097C0");

                entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdDistribuidora).HasColumnName("Id_Distribuidora");

                entity.Property(e => e.IdEmpleado).HasColumnName("Id_Empleado");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK__Ventas__Estado__66603565");

                entity.HasOne(d => d.IdDistribuidoraNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdDistribuidora)
                    .HasConstraintName("FK__Ventas__Id_Distr__6477ECF3");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Ventas__Id_Emple__656C112C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
