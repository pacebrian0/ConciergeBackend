using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase, IUserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserLogic _logic;


        public UserController(ILogger<UserController> logger, IUserLogic logic)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUser()
        {
            var Users = await _logic.GetUsers();
            return Users;
        }

        [HttpGet("{id}")]
        public async Task<User> GetUserById(int id)
        {


            var history = await _logic.GetUserById(id);
            if (history == null)
            {
                throw new ArgumentException($"User with ID '{id}' not found");
            }
            return history;
        }

        //[HttpPost]
        //public async Task<User> CreateUser(User history)
        //{
        //    if (history == null)
        //    {
        //        throw new ArgumentNullException(nameof(history));
        //    }
        //    await _logic.PostUser(history);
        //    return history;
        //}


        [HttpPut("{id}")]
        public async Task<User> UpdateUser(UserPut User)
        {
            if (User == null)
            {
                throw new ArgumentNullException(nameof(User));
            }
            var user = await _logic.GetUserById(User.id);
            user.modifiedOn = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss");
            user.email = User.email;
            user.name = User.name;
            user.surname = User.surname;
            user.isActive = User.isActive;
            if (!BCrypt.Net.BCrypt.Verify(User.password, user.passwordHash))
            {
                user.passwordHash = BCrypt.Net.BCrypt.HashPassword(User.password, BCrypt.Net.BCrypt.GenerateSalt());

            }

            await _logic.UpdateUser(user);
            return user;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //var User = await _dynamoDBContext.LoadAsync<User>(id);
            var history = await _logic.GetUserById(id);
            if (history == null)
            {
                throw new ArgumentException($"User with ID '{id}' not found");
            }
            await _logic.DeleteUser(history);
            return Ok();
        }
    }
}