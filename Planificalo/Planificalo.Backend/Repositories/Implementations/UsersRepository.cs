using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Backend.Repositories.Interfaces;
using Planificalo.Shared.DTOs;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Responses;

namespace Planificalo.Backend.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UsersRepository(DataContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            var user = await _dataContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId.ToString());
            return user;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ActionResponse<User>> UpdateUserAsync(User user)
        {
            try
            {
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new ActionResponse<User>
                    {
                        Success = true,
                        CodError = string.Empty,
                        Entity = user
                    };
                }
                return new ActionResponse<User>
                {
                    Success = false,
                    CodError = "ERR002",
                    Message = string.Join(", ", result.Errors.Select(e => e.Description))
                };
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<User>
                {
                    Success = false,
                    CodError = "DB001",
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<User>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                };
            }
        }

        public async Task<ActionResponse<User>> DeleteUserAsync(Guid userId)
        {
            try
            {
                var user = await _dataContext.Users.FindAsync(userId.ToString());
                if (user == null)
                {
                    return new ActionResponse<User>
                    {
                        Success = false,
                        CodError = "ERR002",
                        Message = "User not found"
                    };
                }

                _dataContext.Users.Remove(user);
                await _dataContext.SaveChangesAsync();

                return new ActionResponse<User>
                {
                    Success = true,
                    CodError = string.Empty,
                    Entity = user
                };
            }
            catch (DbUpdateException ex)
            {
                return new ActionResponse<User>
                {
                    Success = false,
                    CodError = "DB001",
                    Message = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<User>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                };
            }
        }
    }
}