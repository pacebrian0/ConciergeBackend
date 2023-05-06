using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IHistoryController
    {
        Task<History> CreateHistory(HistoryPost history);
        Task<IActionResult> DeleteHistory(int id);
        Task<IEnumerable<History>> GetHistory();
        Task<History> GetHistoryById(int id);
    }
}