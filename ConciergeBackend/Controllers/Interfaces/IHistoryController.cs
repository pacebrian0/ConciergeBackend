using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IHistoryController
    {
        Task<History> CreateHistory(History history);
        Task<IActionResult> DeleteHistory(string id);
        Task<IEnumerable<History>> GetHistory();
        Task<History> GetHistoryById(string id);
    }
}