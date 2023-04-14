using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase, IAuditController
    {
        //private readonly IDynamoDBContext _dynamoDBContext;
        private readonly ILogger<AuditController> _logger;
        private readonly IAuditLogic _logic;


        public AuditController(/*IDynamoDBContext dynamoDBContext,*/ ILogger<AuditController> logger, IAuditLogic logic)
        {
            //_dynamoDBContext = dynamoDBContext ?? throw new ArgumentNullException(nameof(dynamoDBContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<Audit>> GetAudits()
        {
            //var Audits = await _dynamoDBContext.ScanAsync<Audit>(new List<ScanCondition>()).GetRemainingAsync();
            var audits = await _logic.GetAudits();
            return audits;
        }

        [HttpGet("{id}")]
        public async Task<Audit> GetAuditsById(int id)
        {
            //var Audit = await _dynamoDBContext.LoadAsync<Audit>(id);
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
            //var Audit = await _dynamoDBContext.LoadAsync<Audit>(id);
            if (id == null)
            {
                throw new ArgumentException($"Audit with ID '{id}' not found");
            }
            //await _dynamoDBContext.DeleteAsync(Audit);
            return NoContent();
        }
    }
}
