using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IHistoryData
    {
        Task<IEnumerable<History>> GetHistories();
        Task<string> PostHistory(History history);
    }
}