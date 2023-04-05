using Amazon.DynamoDBv2.DataModel;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly ILogger<UserController> _logger;

        public UserController(IDynamoDBContext dynamoDBContext, ILogger<UserController> logger)
        {
            _dynamoDBContext = dynamoDBContext ?? throw new ArgumentNullException(nameof(dynamoDBContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            var Users = await _dynamoDBContext.ScanAsync<User>(new List<ScanCondition>()).GetRemainingAsync();
            return Users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}