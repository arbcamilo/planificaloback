using Microsoft.AspNetCore.Mvc;
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