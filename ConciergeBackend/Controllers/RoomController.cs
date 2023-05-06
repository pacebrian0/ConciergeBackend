using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<Room> GetRoomById(int id)
        {

            var history = await _logic.GetRoomById(id);
            if (history == null)
            {
                throw new ArgumentException($"Room with ID '{id}' not found");
            }
            return history;
        }

        [HttpGet("property/{id}")]
        public async Task<IEnumerable<Room>> GetRoomsByProperty(int id)
        {


            var room = await _logic.GetRoomsByProperty(id);
            if (room == null)
            {
                throw new ArgumentException($"Rooms with property ID '{id}' not found");
            }
            return room;
        }

        [HttpPost]
        public async Task<Room> CreateRoom(RoomPost room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }
            var dbRoom = new Room {
                id = 0,
                name = room.name,
                propertyID = room.propertyID,
                createdBy = room.createdBy,
                modifiedBy = room.createdBy,
                createdOn = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:sszzz"),
                modifiedOn = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:sszzz"),
                status = "A"


            };
            await _logic.PostRoom(dbRoom);
            return dbRoom;
        }


        [HttpPut("{id}")]
        public async Task<Room> UpdateRoom(RoomPut Room)
        {
            if (Room == null)
            {
                throw new ArgumentNullException(nameof(Room));
            }

            var dbRoom = await _logic.GetRoomById(Room.id);

            dbRoom.name = Room.name;
            dbRoom.propertyID = Room.propertyID;
            dbRoom.modifiedBy = Room.modifiedBy;
            dbRoom.modifiedOn = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss");
            dbRoom.status = Room.status;


            await _logic.UpdateRoom(dbRoom);
            return dbRoom;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
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