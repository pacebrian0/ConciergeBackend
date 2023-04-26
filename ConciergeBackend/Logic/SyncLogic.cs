using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;

namespace ConciergeBackend.Logic
{
    public class SyncLogic : ISyncLogic
    {
        private readonly ISyncData _data;

        public SyncLogic(ISyncData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<Sync>> GetSyncs()
        {

            return await _data.GetSyncs();

        }
        public async Task<Sync> GetSyncById(string id)
        {
            return await _data.GetSyncById(id);

        }

        public async Task PostSync(Sync sync)
        {

            //do local logic
            await _data.PostSync(sync, true);

            //do remote logic
            try
            {
                await _data.PostSync(sync, false);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
