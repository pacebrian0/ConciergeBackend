using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IHostController
    {
        void DeleteHost(int id);
        Task<IEnumerable<Models.Host>> GetHostAsync();
        string GetHostById(int id);
        void PostHost([FromBody] Models.Host host);
        void PutHost(int id, [FromBody] Models.Host host);
    }
}