using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IHistoryData
    {
        Task DeleteHistory(History history, bool local);
        Task<IEnumerable<History>> GetHistories();
        Task<History> GetHistoryById(int id);
        Task<History> GetHistoryByReservation(int resID);
        Task<History> GetHistoryByRoom(int roomID);
        Task PostHistory(History history, bool local);
    }
}