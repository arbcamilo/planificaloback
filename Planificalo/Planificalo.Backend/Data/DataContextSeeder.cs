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

            // Crear usuarios adicionales
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "carlos.gomez1@example.com", "Carlos", "Gomez", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "ana.perez2@example.com", "Ana", "Perez", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "luis.lopez3@example.com", "Luis", "Lopez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "maria.garcia4@example.com", "Maria", "Garcia", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "jose.martinez5@example.com", "Jose", "Martinez", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "laura.rodriguez6@example.com", "Laura", "Rodriguez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "juan.hernandez7@example.com", "Juan", "Hernandez", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "marta.sanchez8@example.com", "Marta", "Sanchez", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "pedro.ramirez9@example.com", "Pedro", "Ramirez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "lucia.cruz10@example.com", "Lucia", "Cruz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "andres.morales11@example.com", "Andres", "Morales", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "sofia.fernandez12@example.com", "Sofia", "Fernandez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "diego.torres13@example.com", "Diego", "Torres", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "valentina.mendoza14@example.com", "Valentina", "Mendoza", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "sebastian.ortiz15@example.com", "Sebastian", "Ortiz", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "camila.rivera16@example.com", "Camila", "Rivera", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "nicolas.flores17@example.com", "Nicolas", "Flores", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "daniela.moreno18@example.com", "Daniela", "Moreno", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "alejandro.romero19@example.com", "Alejandro", "Romero", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "isabella.martin20@example.com", "Isabella", "Martin", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "samuel.rojas21@example.com", "Samuel", "Rojas", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "antonio.diaz22@example.com", "Antonio", "Diaz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "carolina.silva23@example.com", "Carolina", "Silva", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "javier.molina24@example.com", "Javier", "Molina", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "paula.ruiz25@example.com", "Paula", "Ruiz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "fernando.morales26@example.com", "Fernando", "Morales", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "adriana.fernandez27@example.com", "Adriana", "Fernandez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "ricardo.torres28@example.com", "Ricardo", "Torres", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "mariana.mendoza29@example.com", "Mariana", "Mendoza", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "julian.ortiz30@example.com", "Julian", "Ortiz", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "angela.rivera31@example.com", "Angela", "Rivera", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "martin.flores32@example.com", "Martin", "Flores", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "patricia.moreno33@example.com", "Patricia", "Moreno", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "victor.romero34@example.com", "Victor", "Romero", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "elena.martin35@example.com", "Elena", "Martin", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "raul.rojas36@example.com", "Raul", "Rojas", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "alberto.diaz37@example.com", "Alberto", "Diaz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "veronica.silva38@example.com", "Veronica", "Silva", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "sergio.molina39@example.com", "Sergio", "Molina", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "monica.ruiz40@example.com", "Monica", "Ruiz", UserType.Admin);
            
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "carlos.gomez1@example.com", "Carlos", "Gomez", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "ana.perez2@example.com", "Ana", "Perez", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "luis.lopez3@example.com", "Luis", "Lopez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "maria.garcia4@example.com", "Maria", "Garcia", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "jose.martinez5@example.com", "Jose", "Martinez", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "laura.rodriguez6@example.com", "Laura", "Rodriguez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "juan.hernandez7@example.com", "Juan", "Hernandez", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "marta.sanchez8@example.com", "Marta", "Sanchez", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "pedro.ramirez9@example.com", "Pedro", "Ramirez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "lucia.cruz10@example.com", "Lucia", "Cruz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "andres.morales11@example.com", "Andres", "Morales", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "sofia.fernandez12@example.com", "Sofia", "Fernandez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "diego.torres13@example.com", "Diego", "Torres", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "valentina.mendoza14@example.com", "Valentina", "Mendoza", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "sebastian.ortiz15@example.com", "Sebastian", "Ortiz", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "camila.rivera16@example.com", "Camila", "Rivera", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "nicolas.flores17@example.com", "Nicolas", "Flores", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "daniela.moreno18@example.com", "Daniela", "Moreno", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "alejandro.romero19@example.com", "Alejandro", "Romero", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "isabella.martin20@example.com", "Isabella", "Martin", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "samuel.rojas21@example.com", "Samuel", "Rojas", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "antonio.diaz22@example.com", "Antonio", "Diaz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "carolina.silva23@example.com", "Carolina", "Silva", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "javier.molina24@example.com", "Javier", "Molina", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "paula.ruiz25@example.com", "Paula", "Ruiz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "fernando.morales26@example.com", "Fernando", "Morales", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "adriana.fernandez27@example.com", "Adriana", "Fernandez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "ricardo.torres28@example.com", "Ricardo", "Torres", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "mariana.mendoza29@example.com", "Mariana", "Mendoza", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "julian.ortiz30@example.com", "Julian", "Ortiz", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "angela.rivera31@example.com", "Angela", "Rivera", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "martin.flores32@example.com", "Martin", "Flores", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "patricia.moreno33@example.com", "Patricia", "Moreno", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "victor.romero34@example.com", "Victor", "Romero", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "elena.martin35@example.com", "Elena", "Martin", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "raul.rojas36@example.com", "Raul", "Rojas", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "alberto.diaz37@example.com", "Alberto", "Diaz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "veronica.silva38@example.com", "Veronica", "Silva", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "sergio.molina39@example.com", "Sergio", "Molina", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "monica.ruiz40@example.com", "Monica", "Ruiz", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "gustavo.morales41@example.com", "Gustavo", "Morales", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "gloria.fernandez42@example.com", "Gloria", "Fernandez", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "hector.torres43@example.com", "Hector", "Torres", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "diana.mendoza44@example.com", "Diana", "Mendoza", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "oscar.ortiz45@example.com", "Oscar", "Ortiz", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "claudia.rivera46@example.com", "Claudia", "Rivera", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "edgar.flores47@example.com", "Edgar", "Flores", UserType.User);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "silvia.moreno48@example.com", "Silvia", "Moreno", UserType.Provider);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "francisco.romero49@example.com", "Francisco", "Romero", UserType.Admin);
            await CreateUserIfNotExists(serviceProvider, usersUnitOfWork, mailHelper, configuration, "irene.martin50@example.com", "Irene", "Martin", UserType.User);
        }

        private static async Task CreateRoleIfNotExists(IUsersUnitOfWork usersUnitOfWork, string roleName)
        {
            await usersUnitOfWork.CheckRoleAsync(roleName);
        }

        private static async Task CreateUserIfNotExists(IServiceProvider serviceProvider, IUsersUnitOfWork usersUnitOfWork, IMailHelper mailHelper, IConfiguration configuration, string email, string firstName, string lastName, UserType userType = UserType.User)
        {
            var user = await usersUnitOfWork.GetUserAsync(email);

            if (user == null)
            {
                // Generar un número de identificación de 7 dígitos
                var random = new Random();
                var documentNumber = random.Next(1000000, 9999999).ToString();

                user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    DocumentType = "CC",
                    DocumentNumber = documentNumber, // Asignar el número de identificación
                    UserType = userType,
                    UserStatus = "Active",
                    BirthDate = new DateOnly(1990, 1, 1),
                    AccountCreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                    EmailConfirmed = false // Set to false to require email confirmation
                };

                var result = await usersUnitOfWork.AddUserAsync(user, "123456");

                if (result.Succeeded)
                {
                    await usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());

                    // Generate email confirmation token
                    var token = await usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
                    var tokenLink = $"{configuration["UrlFrontend"]}/confirmation-email?userId={user.Id}&token={token}";

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

