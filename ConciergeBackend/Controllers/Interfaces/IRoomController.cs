using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IRoomController
    {
        Task<Room> CreateRoom(RoomPost room);
        Task<IActionResult> DeleteRoom(int id);
        Task<IEnumerable<Room>> GetRoom();
        Task<Room> GetRoomById(int id);
        Task<Room> UpdateRoom(RoomPut Room);
        Task<IEnumerable<Room>> GetRoomsByProperty(int id);

    }
}