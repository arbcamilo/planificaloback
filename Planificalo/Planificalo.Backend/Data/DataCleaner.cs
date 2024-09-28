using Microsoft.EntityFrameworkCore;
using Planificalo.Shared.Entities;
using ServiceProvider = Planificalo.Shared.Entities.ServiceProvider;

public static class DataCleaner
{
    public static void Clean(ModelBuilder modelBuilder)
    {
        // Eliminar registros de las tablas dependientes primero
        modelBuilder.Entity<ProductQuote>().HasData(new ProductQuote[] { });
        modelBuilder.Entity<ServiceQuote>().HasData(new ServiceQuote[] { });
        modelBuilder.Entity<GuestEvent>().HasData(new GuestEvent[] { });
        modelBuilder.Entity<Invitation>().HasData(new Invitation[] { });
        modelBuilder.Entity<ProductProvider>().HasData(new ProductProvider[] { });
        modelBuilder.Entity<ServiceProvider>().HasData(new ServiceProvider[] { });

        // Luego eliminar registros de las tablas principales
        modelBuilder.Entity<Quote>().HasData(new Quote[] { });
        modelBuilder.Entity<Product>().HasData(new Product[] { });
        modelBuilder.Entity<Service>().HasData(new Service[] { });
        modelBuilder.Entity<Guest>().HasData(new Guest[] { });
        modelBuilder.Entity<Event>().HasData(new Event[] { });
        modelBuilder.Entity<EventType>().HasData(new EventType[] { });
        modelBuilder.Entity<Provider>().HasData(new Provider[] { });
        modelBuilder.Entity<User>().HasData(new User[] { });
    }
}