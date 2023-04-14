using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IRoomData
    {
        Task DeleteRoom(Room room, bool local);
        Task<Room> GetRoomById(string id);
        Task<IEnumerable<Room>> GetRooms();
        Task PostRoom(Room room, bool local);
        Task UpdateRoom(Room room, bool local);
    }
}
