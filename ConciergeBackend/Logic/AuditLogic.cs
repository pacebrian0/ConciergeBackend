using ConciergeBackend.Data;
using ConciergeBackend.Models;

namespace ConciergeBackend.Logic
{
    public class AuditLogic
    {
        public AuditLogic() {
        }

        public async Task<IEnumerable<Audit>> GetAudits()
        {
            // no need for AWS logic

        }

        public async Task<string> PostAudit(Audit audit)
        {
            //do AWS logic
            AuditData

        }
    }
}
