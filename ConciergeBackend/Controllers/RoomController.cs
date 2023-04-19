using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
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
        private readonly IRoomLogic _logic;


        public RoomController(ILogger<RoomController> logger, IRoomLogic logic)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<Room>> GetRoom()
        {
            var Rooms = await _logic.GetRooms();
            return Rooms;
        }

        [HttpGet("{id}")]
        public async Task<Room> GetRoomById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var history = await _logic.GetRoomById(id);
            if (history == null)
            {
                throw new ArgumentException($"Room with ID '{id}' not found");
            }
            return history;
        }

        [HttpPost]
        public async Task<Room> CreateRoom(Room history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(nameof(history));
            }
            await _logic.PostRoom(history);
            return history;
        }


        [HttpPut("{id}")]
        public async Task<Room> UpdateRoom(string id, Room Room)
        {
            if (Room == null)
            {
                throw new ArgumentNullException(nameof(Room));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (Room.id != id)
            {
                throw new ArgumentException($"The ID of the Room in the body '{Room.id}' does not match the ID '{id}' in the URL");
            }
            await _logic.UpdateRoom(Room);
            return Room;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(string id)
        {
            //var Room = await _dynamoDBContext.LoadAsync<Room>(id);
            var history = await _logic.GetRoomById(id);
            if (history == null)
            {
                throw new ArgumentException($"Room with ID '{id}' not found");
            }
            await _logic.DeleteRoom(history);
            return Ok();
        }
    }
}