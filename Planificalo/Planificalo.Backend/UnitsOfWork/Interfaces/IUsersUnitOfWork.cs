using Microsoft.AspNetCore.Identity;
using Planificalo.Shared.DTOs;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;

namespace Planificalo.Backend.UnitsOfWork.Interfaces
{
    public interface IUsersUnitOfWork
    {
        Task<User> GetUserAsync(Guid userId);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<ActionResponse<User>> UpdateUserAsync(User user); // Agregar este método

        Task<ActionResponse<User>> DeleteUserAsync(Guid userId); // Agregar este método

        Task<ActionResponse<User>> ChangePasswordAsync(User user, string currentPassword, string newPassword); // Agregar este método
    }
}