using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditController : ControllerBase, IAuditController
    {
        private readonly ILogger<AuditController> _logger;
        private readonly IAuditLogic _logic;


        public AuditController(ILogger<AuditController> logger, IAuditLogic logic)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<Audit>> GetAudits()
        {
            var audits = await _logic.GetAudits();
            return audits;
        }

        [HttpGet("{id}")]
        public async Task<Audit> GetAuditsById(int id)
        {
            if (id == null)
            {
                throw new ArgumentException($"Audit with ID '{id}' not found");
            }
            return new Audit();
        }

        [HttpPost]
        public async Task CreateAudit(Audit audit)
        {
            if (audit == null)
            {
                throw new ArgumentNullException(nameof(audit));
            }
            await _logic.PostAudit(audit);
            //await _dynamoDBContext.SaveAsync(Audit);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudit(int id)
        {
            //await _dynamoDBContext.DeleteAsync(Audit);
            return NoContent();
        }
    }
}
