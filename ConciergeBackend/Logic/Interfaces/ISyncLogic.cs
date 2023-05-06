using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface ISyncLogic
    {
        Task<Sync> GetSyncById(int id);
        Task<IEnumerable<Sync>> GetSyncs();
        Task PostSync(Sync sync);
    }
}