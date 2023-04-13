using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase, IRoomController
    {
        private readonly ILogger<RoomController> _logger;

        public RoomController(ILogger<RoomController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<RoomController>
        [HttpGet]
        public async Task<IEnumerable<Room>> GetRoomAsync()
        {
            var Rooms = new List<Room>();
            return Rooms;
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public string GetRoomById(int id)
        {
            return "value";
        }

        // POST api/<RoomController>
        [HttpPost]
        public void PostRoom([FromBody] Room room)
        {
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public void PutRoom(int id, [FromBody] Room room)
        {
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public void DeleteRoom(int id)
        {
        }
    }
}