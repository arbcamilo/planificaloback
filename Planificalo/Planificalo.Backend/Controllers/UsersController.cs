using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Planificalo.Backend.Data;
using Planificalo.Backend.Helpers;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.DTOs;
using Planificalo.Shared.Entities;
using Planificalo.Shared.Enums;
using Planificalo.Shared.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Planificalo.Backend.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersUnitOfWork _usersUnitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMailHelper _mailHelper;
        private readonly DataContext _context;

        public UsersController(IUsersUnitOfWork usersUnitOfWork, IConfiguration configuration, IMailHelper mailHelper, DataContext context)
        {
            _usersUnitOfWork = usersUnitOfWork;
            _configuration = configuration;
            _mailHelper = mailHelper;
            _context = context;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO model)
        {
            User user = model;
            var result = await _usersUnitOfWork.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                switch (user.UserType)
                {
                    case UserType.Admin:
                        await _usersUnitOfWork.AddUserToRoleAsync(user, "Admin");
                        break;

                    case UserType.User:
                        await _usersUnitOfWork.AddUserToRoleAsync(user, "User");
                        break;

                    case UserType.Provider:
                        await _usersUnitOfWork.AddUserToRoleAsync(user, "Provider");
                        break;

                    case UserType.Anonymous:
                        await _usersUnitOfWork.AddUserToRoleAsync(user, "Anonymous");
                        break;
                }

                var response = await SendConfirmationEmailAsync(user, model.Language);
                if (response.Success)
                {
                    return Ok(response);
                }

                return BadRequest(response.Message);
            }
            return BadRequest(result.Errors.FirstOrDefault());
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var result = await _usersUnitOfWork.LoginAsync(model);
            if (result.Succeeded)
            {
                var user = await _usersUnitOfWork.GetUserAsync(model.Email);
                var tokenDTO = BuildToken(user);
                return Ok(tokenDTO);
            }

            if (result.IsLockedOut)
            {
                return BadRequest("The user is locked");
            }

            if (result.IsNotAllowed)
            {
                return BadRequest("The user is not allowed");
            }
            return BadRequest("Invalid login attempt");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _usersUnitOfWork.LogoutAsync();
            return Ok();
        }

        [HttpGet("RecoveryPassword")]
        public async Task<IActionResult> RecoveryPassword(string email, string lenguage)
        {
            var user = await _usersUnitOfWork.GetUserAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            var tokenDTO = BuildToken(user);

            var response = await SendReConfirmationEmailAsync(user, tokenDTO, lenguage.ToLower());
            if (response.Success)
            {
                return Ok(new ActionResponse<User>
                {
                    Success = true,
                    Entity = user,
                    Message = "Email sent successfully"
                });
            }

            return BadRequest(response.Message);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync(string userId, string token)
        {
            token = token.Replace(" ", "+");
            var user = await _usersUnitOfWork.GetUserAsync(new Guid(userId));
            if (user == null)
            {
                return NotFound();
            }

            var result = await _usersUnitOfWork.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault() + " " + token);
            }

            return Ok();
        }

        private async Task<ActionResponse<string>> SendReConfirmationEmailAsync(User user, TokenDTO mytoken, string language)
        {
            var urlfront = _configuration["UrlFrontend"];

            var tokenLink = $"{urlfront}/reset-password?userId={user.Id}&token={mytoken.Token}";

            // Validar que las configuraciones no sean nulas
            var subjectReConfirmationES = _configuration["Email:SubjectRecoveryES"];
            var bodyReConfirmationES = _configuration["Email:BodyRecoveryES"];
            var subjectReConfirmationEN = _configuration["Email:SubjectRecoveryEN"];
            var bodyReConfirmationEN = _configuration["Email:BodyRecoveryEN"];

            string subject, body;
            if (language == "es")
            {
                subject = subjectReConfirmationES;
                body = string.Format(bodyReConfirmationES, tokenLink);
            }
            else
            {
                subject = subjectReConfirmationEN;
                body = string.Format(bodyReConfirmationEN, tokenLink);
            }

            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                return new ActionResponse<string>
                {
                    Success = false,
                    Message = "Email subject or body is not configured properly."
                };
            }

            return _mailHelper.SendEmail(user.FullName, user.Email!, subject, body, language);
        }

        private async Task<ActionResponse<string>> SendConfirmationEmailAsync(User user, string language)
        {
            var mytoken = await _usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);

            var urlfront = _configuration["UrlFrontend"];

            var tokenLink = $"{urlfront}/confirmation-email?userId={user.Id}&token={mytoken}";

            // Validar que las configuraciones no sean nulas
            var subjectConfirmationES = _configuration["Email:SubjectConfirmationES"];
            var bodyConfirmationES = _configuration["Email:BodyConfirmationES"];
            var subjectConfirmationEN = _configuration["Email:SubjectConfirmationEN"];
            var bodyConfirmationEN = _configuration["Email:BodyConfirmationEN"];

            string subject, body;
            if (language == "es")
            {
                subject = subjectConfirmationES;
                body = string.Format(bodyConfirmationES, tokenLink);
            }
            else
            {
                subject = subjectConfirmationEN;
                body = string.Format(bodyConfirmationEN, tokenLink);
            }

            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                return new ActionResponse<string>
                {
                    Success = false,
                    Message = "Email subject or body is not configured properly."
                };
            }

            return _mailHelper.SendEmail(user.FullName, user.Email!, subject, body, language);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ActionResponse<IEnumerable<User>>>> GetAll()
        {
            var users = await _usersUnitOfWork.GetAllUsersAsync();
            return Ok(new ActionResponse<IEnumerable<User>>
            {
                Success = true,
                Entity = users
            });
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ActionResponse<User>>> Update(string id, [FromBody] UserUpdateDTO model)
        {
            try
            {
                var user = await _usersUnitOfWork.GetUserAsync(new Guid(id));
                if (user == null)
                {
                    return NotFound(new ActionResponse<User>
                    {
                        Success = false,
                        Message = "User not found"
                    });
                }

                if (!string.IsNullOrEmpty(model.FirstName))
                {
                    user.FirstName = model.FirstName;
                }
                if (!string.IsNullOrEmpty(model.LastName))
                {
                    user.LastName = model.LastName;
                }
                if (!string.IsNullOrEmpty(model.PhoneNumber))
                {
                    user.PhoneNumber = model.PhoneNumber;
                }

                user.Email = model.Email;

                if (!string.IsNullOrEmpty(model.UserName))
                {
                    user.UserName = model.Email;
                }

                if (!string.IsNullOrEmpty(model.DocumentType))
                {
                    user.DocumentType = model.DocumentType;
                }

                if (!string.IsNullOrEmpty(model.DocumentNumber))
                {
                    user.DocumentNumber = model.DocumentNumber;
                }

                if (!string.IsNullOrEmpty(model.UserType.ToString()))
                {
                    user.UserType = model.UserType;
                }

                if (!string.IsNullOrEmpty(model.UserStatus))
                {
                    user.UserStatus = model.UserStatus;
                }
                if (model.BirthDate != null)
                {
                    user.BirthDate = model.BirthDate;
                }
                if (model.AccountCreationDate != null)
                {
                    user.AccountCreationDate = model.AccountCreationDate;
                }
                if (!string.IsNullOrEmpty(model.Photo))
                {
                    user.Photo = model.Photo;
                }

                var result = await _usersUnitOfWork.UpdateUserAsync(user);
                if (result.Success)
                {
                    return Ok(new ActionResponse<User>
                    {
                        Success = true,
                        Entity = user
                    });
                }

                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    Message = result.Message
                });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    CodError = "DB001",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Admin")]
        public async Task<ActionResult<ActionResponse<User>>> Delete(string id)
        {
            try
            {
                var user = await _usersUnitOfWork.GetUserAsync(new Guid(id));
                if (user == null)
                {
                    return NotFound(new ActionResponse<User>
                    {
                        Success = false,
                        Message = "User not found"
                    });
                }

                var result = await _usersUnitOfWork.DeleteUserAsync(new Guid(user.Id));

                if (result.Success)
                {
                    return Ok(new ActionResponse<User>
                    {
                        Success = true,
                        Entity = user
                    });
                }

                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    Message = result.Message
                });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    CodError = "DB001",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                });
            }
        }

        [HttpPut("ChangePassword")]
        [AllowAnonymous]
        public async Task<ActionResult<ActionResponse<User>>> ChangePassword([FromBody] ChangePasswordDTO model)
        {
            try
            {
                var user = await _usersUnitOfWork.GetUserAsync(model.Email);
                if (user == null)
                {
                    return NotFound(new ActionResponse<User>
                    {
                        Success = false,
                        Message = "User not found"
                    });
                }
                var result = await _usersUnitOfWork.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Success)
                {
                    return Ok(new ActionResponse<User>
                    {
                        Success = true,
                        Message = "Password changed successfully",
                        Entity = user
                    });
                }
                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    Message = result.Message
                });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    CodError = "DB001",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ActionResponse<User>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                });
            }
        }

        private TokenDTO BuildToken(User user)
        {
            var claims = new List<Claim>
            {
                new("id", user.Id),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new("FirstName", user.FirstName),
                new("LastName", user.LastName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddYears(30);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );
            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}