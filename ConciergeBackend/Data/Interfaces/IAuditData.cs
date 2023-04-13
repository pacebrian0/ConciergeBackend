using ConciergeBackend.Models;

namespace ConciergeBackend.Data
{
    public interface IAuditData
    {
        Task<IEnumerable<Audit>> GetAudits();
        Task<string> PostAudit(Audit audit);
    }
}