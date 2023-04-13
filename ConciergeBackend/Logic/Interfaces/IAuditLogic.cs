using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IAuditLogic
    {
        Task<IEnumerable<Audit>> GetAudits();
        Task<string> PostAudit(Audit audit);
    }
}