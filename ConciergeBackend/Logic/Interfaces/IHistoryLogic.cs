using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IHistoryLogic
    {
        Task DeleteHistory(History audit);
        Task<History> GetHistoryById(int id);
        Task<History> GetHistoryByReservation(int resID);
        Task<History> GetHistoryByRoom(int roomID);
        Task<IEnumerable<History>> GetHistorys();
        Task PostHistory(History audit);
    }
}