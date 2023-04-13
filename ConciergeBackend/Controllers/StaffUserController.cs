using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffUserController : ControllerBase, IStaffUserController
    {
        private readonly ILogger<StaffUserController> _logger;

        public StaffUserController(ILogger<StaffUserController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<StaffUserController>
        [HttpGet]
        public async Task<IEnumerable<StaffUser>> GetStaffUserAsync()
        {
            var StaffUsers = new List<StaffUser>();
            return StaffUsers;
        }

        // GET api/<StaffUserController>/5
        [HttpGet("{id}")]
        public string GetStaffUserById(int id)
        {
            return "value";
        }

        // POST api/<StaffUserController>
        [HttpPost]
        public void PostStaffUser([FromBody] StaffUser staffUser)
        {
        }

        // PUT api/<StaffUserController>/5
        [HttpPut("{id}")]
        public void PutStaffUser(int id, [FromBody] StaffUser staffUser)
        {
        }

        // DELETE api/<StaffUserController>/5
        [HttpDelete("{id}")]
        public void DeleteStaffUser(int id)
        {
        }
    }
}