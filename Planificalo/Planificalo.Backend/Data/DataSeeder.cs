using Microsoft.EntityFrameworkCore;
using Planificalo.Shared.Entities;
using System;

namespace Planificalo.Backend.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    DocumentType = "Cedula",
                    IdentityDocument = 123456789,
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                    Phone = "1234567890",
                    UserStatus = "Active",
                    BirthDate = new DateTime(1990, 1, 1),
                    AccountCreationDate = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    DocumentType = "Cedula",
                    IdentityDocument = 987654321,
                    Name = "Jane Smith",
                    Email = "janesmith@example.com",
                    Phone = "0987654321",
                    UserStatus = "Inactive",
                    BirthDate = new DateTime(1992, 2, 2),
                    AccountCreationDate = DateTime.Now
                }
            );

            // Seed Providers
            modelBuilder.Entity<Provider>().HasData(
                new Provider
                {
                    Id = 1,
                    Name = "Provider One",
                    Country = "Country One",
                    Department = "Department One",
                    City = "City One",
                    Address = "Address One",
                    Email = "providerone@example.com",
                    ContactPhone = "1234567890",
                    IsNaturalPerson = true,
                    Status = "Active",
                    DocumentType = "Cedula",
                    IdentityDocument = 123456789
                },
                new Provider
                {
                    Id = 2,
                    Name = "Provider Two",
                    Country = "Country Two",
                    Department = "Department Two",
                    City = "City Two",
                    Address = "Address Two",
                    Email = "providertwo@example.com",
                    ContactPhone = "0987654321",
                    IsNaturalPerson = false,
                    Status = "Inactive",
                    DocumentType = "Cedula",
                    IdentityDocument = 987654321
                }
            );

            // Seed Events
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Event One",
                    UserId = 1,
                    Location = "Location One",
                    EventTypeId = 1,
                    Date = DateTime.Now,
                    Image = "image1.jpg"
                },
                new Event
                {
                    Id = 2,
                    Title = "Event Two",
                    UserId = 2,
                    Location = "Location Two",
                    EventTypeId = 2,
                    Date = DateTime.Now.AddDays(1),
                    Image = "image2.jpg"
                }
            );

            // Seed EventTypes
            modelBuilder.Entity<EventType>().HasData(
                new EventType { Id = 1, Name = "Conference" },
                new EventType { Id = 2, Name = "Workshop" }
            );

            // Seed Services
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    ServiceType = "Catering",
                    Price = 100.00m,
                    Quantity = "10",
                    Description = "Catering Service"
                },
                new Service
                {
                    Id = 2,
                    ServiceType = "Photography",
                    Price = 200.00m,
                    Quantity = "5",
                    Description = "Photography Service"
                }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductType = "Chair",
                    Price = 10.00m,
                    Amount = 100,
                    Description = "Plastic Chair"
                },
                new Product
                {
                    Id = 2,
                    ProductType = "Table",
                    Price = 20.00m,
                    Amount = 50,
                    Description = "Wooden Table"
                }
            );

            // Seed Quotes
            modelBuilder.Entity<Quote>().HasData(
                new Quote
                {
                    Id = 1,
                    EventId = 1,
                    ProviderId = 1,
                    Quantity = 10,
                    Total = 1000.00m,
                    QuoteDate = DateTime.Now,
                    QuoteStatus = "Pending",
                    Notes = "Initial quote for Event One"
                },
                new Quote
                {
                    Id = 2,
                    EventId = 2,
                    ProviderId = 2,
                    Quantity = 5,
                    Total = 500.00m,
                    QuoteDate = DateTime.Now,
                    QuoteStatus = "Confirmed",
                    Notes = "Initial quote for Event Two"
                }
            );

            // Seed ProductQuotes
            modelBuilder.Entity<ProductQuote>().HasData(
                new ProductQuote { QuoteId = 1, ProductId = 1, Amount = 10 },
                new ProductQuote { QuoteId = 2, ProductId = 2, Amount = 5 }
            );

            // Seed ServiceQuotes
            modelBuilder.Entity<ServiceQuote>().HasData(
                new ServiceQuote { QuoteId = 1, ServiceId = 1, Quantity = 10 },
                new ServiceQuote { QuoteId = 2, ServiceId = 2, Quantity = 5 }
            );

            // Seed Guests
            modelBuilder.Entity<Guest>().HasData(
                new Guest
                {
                    Id = 1,
                    Name = "Guest One",
                    GuestStatus = true,
                    Email = "guestone@example.com",
                },
                new Guest
                {
                    Id = 2,
                    Name = "Guest Two",
                    GuestStatus = false,
                    Email = "guesttwo@example.com",
                }
            );

            // Seed GuestEvents
            modelBuilder.Entity<GuestEvent>().HasData(
                new GuestEvent { EventId = 1, GuestId = 1 },
                new GuestEvent { EventId = 2, GuestId = 2 }
            );

            // Seed Invitations
            modelBuilder.Entity<Invitation>().HasData(
                new Invitation
                {
                    Id = 1,
                    EventId = 1,
                    GuestId = 1,
                    SendDate = DateTime.Now,
                    InvitationStatus = true
                },
                new Invitation
                {
                    Id = 2,
                    EventId = 2,
                    GuestId = 2,
                    SendDate = DateTime.Now.AddDays(1),
                    InvitationStatus = false
                }
            );

            // Seed ProductProviders
            modelBuilder.Entity<ProductProvider>().HasData(
                new ProductProvider { ProviderId = 1, ProductId = 1 },
                new ProductProvider { ProviderId = 2, ProductId = 2 }
            );

            // Seed ServiceProviders
            modelBuilder.Entity<Shared.Entities.ServiceProvider>().HasData(
                new Shared.Entities.ServiceProvider { ProviderId = 1, ServiceId = 1 },
                new Shared.Entities.ServiceProvider { ProviderId = 2, ServiceId = 2 }
            );
        }
    }
}