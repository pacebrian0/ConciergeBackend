using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
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
        private readonly IStaffUserLogic _logic;


        public StaffUserController(ILogger<StaffUserController> logger, IStaffUserLogic logic)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<StaffUser>> GetStaffUser()
        {
            var StaffUsers = await _logic.GetStaffUsers();
            return StaffUsers;
        }

        [HttpGet("{id}")]
        public async Task<StaffUser> GetStaffUserById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var history = await _logic.GetStaffUserById(id);
            if (history == null)
            {
                throw new ArgumentException($"StaffUser with ID '{id}' not found");
            }
            return history;
        }

        [HttpPost]
        public async Task<StaffUser> CreateStaffUser(StaffUser history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(nameof(history));
            }
            await _logic.PostStaffUser(history);
            return history;
        }


        [HttpPut("{id}")]
        public async Task<StaffUser> UpdateStaffUser(string id, StaffUser StaffUser)
        {
            if (StaffUser == null)
            {
                throw new ArgumentNullException(nameof(StaffUser));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (StaffUser.id != id)
            {
                throw new ArgumentException($"The ID of the StaffUser in the body '{StaffUser.id}' does not match the ID '{id}' in the URL");
            }
            await _logic.UpdateStaffUser(StaffUser);
            return StaffUser;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffUser(string id)
        {
            //var StaffUser = await _dynamoDBContext.LoadAsync<StaffUser>(id);
            var history = await _logic.GetStaffUserById(id);
            if (history == null)
            {
                throw new ArgumentException($"StaffUser with ID '{id}' not found");
            }
            await _logic.DeleteStaffUser(history);
            return Ok();
        }
    }
}