using Microsoft.Extensions.DependencyInjection;
using Planificalo.Backend.Helpers;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Planificalo.Backend.Data
{
    public static class DataContextSeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
        {
            var usersUnitOfWork = serviceProvider.GetRequiredService<IUsersUnitOfWork>();
            var mailHelper = serviceProvider.GetRequiredService<IMailHelper>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            await CreateRoleIfNotExists(usersUnitOfWork, "Admin");
            await CreateRoleIfNotExists(usersUnitOfWork, "Anonymous");
            await CreateRoleIfNotExists(usersUnitOfWork, "User");
            await CreateRoleIfNotExists(usersUnitOfWork, "Provider");

            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "juan.arboleda@gmail.com", "Juan Camilo", "Arboleda Cano");
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "jhondigon@gmail.com", "Jhon Alejandro", "Díaz");
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "paolita2502@gmail.com", "Paola Andrea", "Molina");
        }

        private static async Task CreateRoleIfNotExists(IUsersUnitOfWork usersUnitOfWork, string roleName)
        {
            await usersUnitOfWork.CheckRoleAsync(roleName);
        }

        private static async Task CreateUserIfNotExists(IServiceProvider serviceProvider, IUsersUnitOfWork usersUnitOfWork, IMailHelper mailHelper, IConfiguration configuration, string email, string firstName, string lastName)
        {
            var user = await usersUnitOfWork.GetUserAsync(email);

            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    DocumentType = "CC",
                    UserType = UserType.Admin,
                    UserStatus = "Active",
                    BirthDate = new DateOnly(1990, 1, 1),
                    AccountCreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                    EmailConfirmed = false // Set to false to require email confirmation
                };

                var result = await usersUnitOfWork.AddUserAsync(user, "123456");

                if (result.Succeeded)
                {
                    await usersUnitOfWork.AddUserToRoleAsync(user, "Admin");

                    // Generate email confirmation token
                    var token = await usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
                    var tokenLink = $"{configuration["UrlFrontend"]}/confirmemail?userId={user.Id}&token={token}";

                    // Ensure email is not null before sending
                    if (!string.IsNullOrEmpty(user.Email))
                    {
                        // Send confirmation email
                        var emailResult = mailHelper.SendEmail(
                            user.FullName,
                            user.Email,
                            configuration["Email:SubjectConfirmationES"]!,
                            string.Format(configuration["Email:BodyConfirmationES"]!, tokenLink),
                            "es"
                        );

                        if (!emailResult.Success)
                        {
                            // Handle email sending failure
                            Console.WriteLine($"Failed to send confirmation email: {emailResult.Message}");
                        }
                        else
                        {
                            // Confirm the email
                            var confirmResult = await usersUnitOfWork.ConfirmEmailAsync(user, token);
                            if (!confirmResult.Succeeded)
                            {
                                Console.WriteLine($"Failed to confirm email: {string.Join(", ", confirmResult.Errors.Select(e => e.Description))}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("User email is null or empty, cannot send confirmation email.");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to create user {firstName} {lastName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}