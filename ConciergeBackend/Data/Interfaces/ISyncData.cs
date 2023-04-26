using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface ISyncData
    {
        Task<IEnumerable<Sync>> GetSyncs();
        Task PostSync(Sync sync, bool local);
        Task UpdateSync(Sync sync, bool local);
        Task<Sync> GetSyncById(string id);
    }
}