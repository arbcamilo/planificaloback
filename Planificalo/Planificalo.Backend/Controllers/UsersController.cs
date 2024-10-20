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
                    return Ok();
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
                return Ok(BuildToken(user));
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

        private async Task<ActionResponse<string>> SendConfirmationEmailAsync(User user, string language)
        {
            var mytoken = await _usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
            var tokenLink = Url.Action("ConfirmEmail", "Users", new
            {
                userId = user.Id,
                token = mytoken
            }, protocol: HttpContext.Request.Scheme);

            var urlfront = _configuration["UrlFrontend"];

            tokenLink = $"{urlfront}/confirmemail?userId={user.Id}&token={mytoken}";

            // Validar que las configuraciones no sean nulas
            var subjectConfirmationES = _configuration["Email:SubjectConfirmationES"];
            var bodyConfirmationES = _configuration["Email:BodyConfirmationES"];
            var subjectConfirmationEN = _configuration["Email:SubjectConfirmationEN"];
            var bodyConfirmationEN = _configuration["Email:BodyConfirmationEN"];

            if (string.IsNullOrEmpty(subjectConfirmationES))
            {
                Console.WriteLine("Email:SubjectConfirmationES is null or empty");
            }
            if (string.IsNullOrEmpty(bodyConfirmationES))
            {
                Console.WriteLine("Email:BodyConfirmationES is null or empty");
            }
            if (string.IsNullOrEmpty(subjectConfirmationEN))
            {
                Console.WriteLine("Email:SubjectConfirmationEN is null or empty");
            }
            if (string.IsNullOrEmpty(bodyConfirmationEN))
            {
                Console.WriteLine("Email:BodyConfirmationEN is null or empty");
            }

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<ActionResult<ActionResponse<User>>> Update(string id, [FromBody] UserDTO model)
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

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Email;
                user.DocumentType = model.DocumentType;
                user.UserType = model.UserType;
                user.Photo = model.Photo;
                user.UserStatus = model.UserStatus;

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

        private TokenDTO BuildToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, user.Id),
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