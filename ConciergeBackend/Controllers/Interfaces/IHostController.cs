using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IHostController
    {
        Task<Models.Host> CreateHost(Models.Host history);
        Task<IActionResult> DeleteHost(int id);
        Task<IEnumerable<Models.Host>> GetHost();
        Task<Models.Host> GetHostById(int id);
        Task<Models.Host> UpdateHost(int id, Models.Host Host);
    }
}