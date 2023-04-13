using ConciergeBackend.Controllers.Interfaces;
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

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUserAsync()
        {
            var Users = new List<User>();
            return Users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string GetUserById(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void PostUser([FromBody] User user)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void PutUser(int id, [FromBody] User user)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
        }
    }
}