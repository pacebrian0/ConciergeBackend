using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IHistoryData
    {
        Task DeleteHistory(History history, bool local);
        Task<IEnumerable<History>> GetHistories();
        Task<History> GetHistoryById(int id);
        Task PostHistory(History history, bool local);
    }
}