using Amazon.DynamoDBv2.DataModel;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly ILogger<AuditController> _logger;

        public AuditController(IDynamoDBContext dynamoDBContext, ILogger<AuditController> logger)
        {
            _dynamoDBContext = dynamoDBContext ?? throw new ArgumentNullException(nameof(dynamoDBContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IEnumerable<Audit>> Get()
        {
            var Audits = await _dynamoDBContext.ScanAsync<Audit>(new List<ScanCondition>()).GetRemainingAsync();
            return Audits;
        }

        [HttpGet("{id}")]
        public async Task<Audit> Get(string id)
        {
            var Audit = await _dynamoDBContext.LoadAsync<Audit>(id);
            if (Audit == null)
            {
                throw new ArgumentException($"Audit with ID '{id}' not found");
            }
            return Audit;
        }

        [HttpPost]
        public async Task<Audit> Create(Audit Audit)
        {
            if (Audit == null)
            {
                throw new ArgumentNullException(nameof(Audit));
            }
            await _dynamoDBContext.SaveAsync(Audit);
            return Audit;
        }

        [HttpPut("{id}")]
        public async Task<Audit> Update(string id, Audit Audit)
        {
            if (Audit == null)
            {
                throw new ArgumentNullException(nameof(Audit));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (Audit.id != id)
            {
                throw new ArgumentException($"The ID of the Audit in the body '{Audit.id}' does not match the ID '{id}' in the URL");
            }
            await _dynamoDBContext.SaveAsync(Audit);
            return Audit;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Audit = await _dynamoDBContext.LoadAsync<Audit>(id);
            if (Audit == null)
            {
                throw new ArgumentException($"Audit with ID '{id}' not found");
            }
            await _dynamoDBContext.DeleteAsync(Audit);
            return NoContent();
        }
    }
}
