using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IRoomController
    {
        Task<Room> CreateRoom(Room history);
        Task<IActionResult> DeleteRoom(string id);
        Task<IEnumerable<Room>> GetRoom();
        Task<Room> GetRoomById(string id);
        Task<Room> UpdateRoom(string id, Room Room);
    }
}