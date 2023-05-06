using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IRoomLogic
    {
        Task DeleteRoom(Room audit);
        Task<Room> GetRoomById(int id);
        Task<IEnumerable<Room>> GetRooms();
        Task PostRoom(Room audit);
        Task UpdateRoom(Room audit);
        Task<IEnumerable<Room>> GetRoomsByProperty(int id);
    }
}