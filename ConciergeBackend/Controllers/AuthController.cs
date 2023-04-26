using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase, IAuthController
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDTO request)
        {
            string passHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.email = request.Username;
            user.passwordHash = passHash;

            return Ok(User);

        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDTO request)
        {
            if (user.email != request.Username)
            {
                return BadRequest("Login Incorrect.");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.passwordHash))
            {
                return BadRequest("Login Incorrect.");
            }
            string token = CreateToken(user);
            return Ok(token);

        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
