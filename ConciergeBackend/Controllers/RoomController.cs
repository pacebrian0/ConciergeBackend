using Amazon.DynamoDBv2.DataModel;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IDynamoDBContext dynamoDBContext, ILogger<RoomController> logger)
        {
            _dynamoDBContext = dynamoDBContext ?? throw new ArgumentNullException(nameof(dynamoDBContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<RoomController>
        [HttpGet]
        public async Task<IEnumerable<Room>> GetAsync()
        {
            var Rooms = await _dynamoDBContext.ScanAsync<Room>(new List<ScanCondition>()).GetRemainingAsync();
            return Rooms;
        }

        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoomController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}