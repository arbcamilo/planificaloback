using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Planificalo.Backend.Data;
using Planificalo.Backend.Helpers;
using Planificalo.Backend.UnitsOfWork.Interfaces;
using Planificalo.Shared.DTOs;
using Planificalo.Shared.Entities;
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
                await _usersUnitOfWork.AddUserToRoleAsync(user, user.UserType.ToString());
                var response = await SendConfirmationEmailAsync(user, model.Language);
                if (response.Success)
                {
                    return NoContent();
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
             return NoContent();
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
            if (result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault() + " " + token);
            }

            return NoContent();
        }

        private async Task<ActionResponse<string>> SendConfirmationEmailAsync(User user, string language)
        {
            var mytoken = await _usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
            var tokenLink = Url.Action("ConfirmEmail", "Users", new
            {
                userId = user.Id,
                token = mytoken
            }, protocol: HttpContext.Request.Scheme, _configuration["UrlFrontend"]);

            if (language == "es")
            {
                return _mailHelper.SendEmail(user.FullName, user.Email!, _configuration["Mail:SubjectConfirmationES"]!, string.Format(_configuration["Mail:BodyConfirmationES"]!, tokenLink), language);
            }

            return _mailHelper.SendEmail(user.FullName, user.Email, _configuration["Mail:SubjectConfirmationES"]!, string.Format(_configuration["Mail:BodyConfirmationES"]!, tokenLink), language);
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
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new("FirstName", user.FirstName),
                new("LastName", user.LastName),
                new("Photo", user.Photo ?? string.Empty)
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
