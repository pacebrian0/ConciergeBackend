using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Host = ConciergeBackend.Models.Host;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : ControllerBase
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly ILogger<HostController> _logger;

        public HostController(IDynamoDBContext dynamoDBContext, ILogger<HostController> logger)
        {
            _dynamoDBContext = dynamoDBContext ?? throw new ArgumentNullException(nameof(dynamoDBContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<HostController>
        [HttpGet]
        public async Task<IEnumerable<Host>> GetAsync()
        {
            var hosts = await _dynamoDBContext.ScanAsync<Host>(new List<ScanCondition>()).GetRemainingAsync();
            return hosts;
        }

        // GET api/<HostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HostController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
