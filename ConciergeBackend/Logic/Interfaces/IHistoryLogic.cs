using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IHistoryLogic
    {
        Task DeleteHistory(History audit);
        Task<History> GetHistoryById(int id);
        Task<IEnumerable<History>> GetHistorys();
        Task PostHistory(History audit);
    }
}