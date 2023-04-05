using Amazon.DynamoDBv2.DataModel;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffUserController : ControllerBase
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly ILogger<StaffUserController> _logger;

        public StaffUserController(IDynamoDBContext dynamoDBContext, ILogger<StaffUserController> logger)
        {
            _dynamoDBContext = dynamoDBContext ?? throw new ArgumentNullException(nameof(dynamoDBContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<StaffUserController>
        [HttpGet]
        public async Task<IEnumerable<StaffUser>> GetAsync()
        {
            var StaffUsers = await _dynamoDBContext.ScanAsync<StaffUser>(new List<ScanCondition>()).GetRemainingAsync();
            return StaffUsers;
        }

        // GET api/<StaffUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StaffUserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StaffUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StaffUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}