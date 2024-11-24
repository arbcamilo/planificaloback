using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Planificalo.Shared.Entities;

namespace Planificalo.Backend.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Revocation> Revocations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shared.Entities.ServiceProvider> ServiceProviders { get; set; }
        public DbSet<ProductProvider> ProductProviders { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<ProductQuote> ProductQuotes { get; set; }
        public DbSet<ServiceQuote> ServiceQuotes { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestEvent> GuestEvents { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary key for ProductQuote
            modelBuilder.Entity<ProductQuote>()
                .HasKey(pq => new { pq.QuoteId, pq.ProductId });

            // Define composite primary key for ServiceQuote
            modelBuilder.Entity<ServiceQuote>()
                .HasKey(sq => new { sq.QuoteId, sq.ServiceId });

            // Define composite primary key for GuestEvent
            modelBuilder.Entity<GuestEvent>()
                .HasKey(ge => new { ge.EventId, ge.GuestId });

            // Define composite primary key for ProductProvider
            modelBuilder.Entity<ProductProvider>()
                .HasKey(pp => new { pp.ProviderId, pp.ProductId });

            // Define composite primary key for ServiceProvider
            modelBuilder.Entity<Shared.Entities.ServiceProvider>()
                .HasKey(sp => new { sp.ProviderId, sp.ServiceId });
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