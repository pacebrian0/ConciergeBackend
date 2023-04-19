using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<User> GetUserById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var history = await _logic.GetUserById(id);
            if (history == null)
            {
                throw new ArgumentException($"User with ID '{id}' not found");
            }
            return history;
        }

        [HttpPost]
        public async Task<User> CreateUser(User history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(nameof(history));
            }
            await _logic.PostUser(history);
            return history;
        }


        [HttpPut("{id}")]
        public async Task<User> UpdateUser(string id, User User)
        {
            if (User == null)
            {
                throw new ArgumentNullException(nameof(User));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (User.id != id)
            {
                throw new ArgumentException($"The ID of the User in the body '{User.id}' does not match the ID '{id}' in the URL");
            }
            await _logic.UpdateUser(User);
            return User;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
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