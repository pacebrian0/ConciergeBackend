using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IAuditController
    {
        Task<string> CreateAudit(Audit audit);
        Task<IActionResult> DeleteAudit(int id);
        Task<IEnumerable<Audit>> GetAudits();
        Task<Audit> GetAuditsById(int id);
        Task<Audit> UpdateAudit(int id, Audit Audit);
    }
}