using ConciergeBackend.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Host = ConciergeBackend.Models.Host;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : ControllerBase, IHostController
    {
        private readonly ILogger<HostController> _logger;

        public HostController(ILogger<HostController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<HostController>
        [HttpGet]
        public async Task<IEnumerable<Host>> GetHostAsync()
        {
            var hosts = new List<Host>();
            return hosts;
        }

        // GET api/<HostController>/5
        [HttpGet("{id}")]
        public string GetHostById(int id)
        {
            return "value";
        }

        // POST api/<HostController>
        [HttpPost]
        public void PostHost([FromBody] Host host)
        {
        }

        // PUT api/<HostController>/5
        [HttpPut("{id}")]
        public void PutHost(int id, [FromBody] Host host)
        {
        }

        // DELETE api/<HostController>/5
        [HttpDelete("{id}")]
        public void DeleteHost(int id)
        {
        }
    }
}
