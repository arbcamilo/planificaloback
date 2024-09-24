using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<UsuarioNormal> UsuariosNormales { get; set; }
        public DbSet<UsuarioAnonimo> UsuariosAnonimos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Desistimiento> Desistimientos { get; set; }
        public DbSet<TipoEvento> TiposEvento { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProveedorServicio> ProveedorServicios { get; set; }
        public DbSet<ProveedorProducto> ProveedorProductos { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<CotizacionProducto> CotizacionProductos { get; set; }
        public DbSet<CotizacionServicio> CotizacionServicios { get; set; }
        public DbSet<Invitado> Invitados { get; set; }
        public DbSet<EventoInvitado> EventoInvitados { get; set; }
        public DbSet<Invitacion> Invitaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => new { u.TipoDocumento, u.DocumentoIdentidad })
                .IsUnique();

            modelBuilder.Entity<Proveedor>()
                .HasIndex(p => new { p.TipoDocumento, p.DocumentoIdentidad })
                .IsUnique();

            // Definir clave primaria compuesta para CotizacionProducto
            modelBuilder.Entity<CotizacionProducto>()
                .HasKey(cp => new { cp.CotizacionId, cp.ProductoId });

            // Definir clave primaria compuesta para CotizacionServicio
            modelBuilder.Entity<CotizacionServicio>()
                .HasKey(cs => new { cs.CotizacionId, cs.ServicioId });

            // Definir clave primaria compuesta para EventoInvitado
            modelBuilder.Entity<EventoInvitado>()
                .HasKey(ei => new { ei.EventoId, ei.InvitadoId });

            // Definir clave primaria compuesta para ProveedorProducto
            modelBuilder.Entity<ProveedorProducto>()
                .HasKey(pp => new { pp.ProveedorId, pp.ProductoId });

            // Definir clave primaria compuesta para ProveedorServicio
            modelBuilder.Entity<ProveedorServicio>()
                .HasKey(ps => new { ps.ProveedorId, ps.ServicioId });

            DisableCascadeDelete(modelBuilder);
        }

        private void DisableCascadeDelete(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}