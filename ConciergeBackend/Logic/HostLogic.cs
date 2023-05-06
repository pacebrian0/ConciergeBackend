using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using Host = ConciergeBackend.Models.Host;

namespace ConciergeBackend.Logic
{
    public class HostLogic : IHostLogic
    {
        private readonly IHostData _data;

        public HostLogic(IHostData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<Host>> GetHosts()
        {
            // no need for AWS logic
            return await _data.GetHosts();

        }
        public async Task<Host> GetHostById(int id)
        {
            // no need for AWS logic
            return await _data.GetHostById(id);

        }

        public async Task PostHost(Host audit)
        {
            //do AWS logic

            //do local logic
            await _data.PostHost(audit, true);
        }

        public async Task UpdateHost(Host audit)
        {
            //do AWS logic

            //do local logic
            await _data.UpdateHost(audit, true);
        }

        public async Task DeleteHost(Host audit)
        {
            //do AWS logic

            //do local logic
            await _data.DeleteHost(audit, true);
        }
    }
}
