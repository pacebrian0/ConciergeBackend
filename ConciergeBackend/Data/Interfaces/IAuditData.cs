using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IAuditData
    {
        Task<IEnumerable<Audit>> GetAudits();
        Task PostAudit(Audit audit, bool local);
    }
}