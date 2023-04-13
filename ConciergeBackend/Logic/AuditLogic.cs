using ConciergeBackend.Data;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Serilog;

namespace ConciergeBackend.Logic
{
    public class AuditLogic : IAuditLogic
    {
        private readonly IAuditData _data;

        public AuditLogic(IAuditData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<Audit>> GetAudits()
        {
            // no need for AWS logic
            return await _data.GetAudits();

        }

        public async Task<string> PostAudit(Audit audit)
        {
            //do AWS logic

            //do local logic
            return await _data.PostAudit(audit);

        }
    }
}
