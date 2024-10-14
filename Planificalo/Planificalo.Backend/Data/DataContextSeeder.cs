using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Enums;
using System;
using System.Threading.Tasks;

namespace Planificalo.Backend.Data
{
    public static class DataContextSeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var adminEmail = "juan.arboleda@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var user = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Juan Camilo",
                    LastName = "Arboleda Cano",
                    DocumentType = "CC",
                    UserType = UserType.Admin,
                    UserStatus = "Active",
                    BirthDate = new DateOnly(1990, 1, 1),
                    AccountCreationDate = DateOnly.FromDateTime(DateTime.UtcNow)
                };

                var result = await userManager.CreateAsync(user, "123456");

                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync("Admin"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                    }

                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}