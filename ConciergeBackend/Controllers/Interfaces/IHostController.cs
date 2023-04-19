using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IHostController
    {
        Task<Models.Host> CreateHost(Models.Host history);
        Task<IActionResult> DeleteHost(string id);
        Task<IEnumerable<Models.Host>> GetHost();
        Task<Models.Host> GetHostById(string id);
        Task<Models.Host> UpdateHost(string id, Models.Host Host);
    }
}