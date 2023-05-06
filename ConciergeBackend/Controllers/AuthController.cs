using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
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

        private readonly IUserLogic _ulogic;
        private readonly IConfiguration _conf;


        public AuthController(ILogger<AuthController> logger,  IUserLogic uLogic, IConfiguration conf)
        {
            _ulogic = uLogic;
            _conf = conf;
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDTO>> Register(UserRegisterDTO request)
        {
            var user = await _ulogic.GetUserByEmail(request.Username);
            if (user != null)
            {
                return BadRequest("User Exists");
            }

            string passHash = BCrypt.Net.BCrypt.HashPassword(request.Password, BCrypt.Net.BCrypt.GenerateSalt());
            user = new User
            {
                name = request.Name,
                surname = request.Surname,
                passwordHash = passHash,
                email = request.Username
            };

            var id = await _ulogic.PostUser(user);

            return new UserResponseDTO { ID=id, Token= CreateToken(user)};

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDTO>> Login(UserLoginDTO request)
        {
            var user = await _ulogic.GetUserByEmail(request.Username);
            if (user == null)
            {
                return BadRequest("Login Incorrect.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.passwordHash))
            {
                return BadRequest("Login Incorrect.");
            }

            return new UserResponseDTO { ID = user.id, Token = CreateToken(user) };
            ;

        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


    }
}
