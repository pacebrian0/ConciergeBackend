using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IRoomController
    {
        void DeleteRoom(int id);
        Task<IEnumerable<Room>> GetRoomAsync();
        string GetRoomById(int id);
        void PostRoom([FromBody] Room room);
        void PutRoom(int id, [FromBody] Room room);
    }
}