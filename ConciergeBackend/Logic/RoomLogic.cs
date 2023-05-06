using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;

namespace ConciergeBackend.Logic
{
    public class RoomLogic : IRoomLogic
    {
        private readonly IRoomData _data;

        public RoomLogic(IRoomData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            // no need for AWS logic
            return await _data.GetRooms();

        }
        public async Task<Room> GetRoomById(int id)
        {
            // no need for AWS logic
            return await _data.GetRoomById(id);

        }

        public async Task PostRoom(Room audit)
        {
            //do AWS logic

            //do local logic
            await _data.PostRoom(audit, true);
        }

        public async Task UpdateRoom(Room audit)
        {
            //do AWS logic

            //do local logic
            await _data.UpdateRoom(audit, true);
        }

        public async Task DeleteRoom(Room audit)
        {
            //do AWS logic

            //do local logic
            await _data.DeleteRoom(audit, true);
        }

        public async Task<IEnumerable<Room>> GetRoomsByProperty(int id)
        {
            return await _data.GetRoomsByProperty(id);
        }
    }
}
