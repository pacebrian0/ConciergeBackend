using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IAuditLogic
    {
        public Task<IEnumerable<Audit>> GetAudits();
        public Task<string> PostAudit(Audit audit);

    }
}
