using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
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
        private readonly IHostLogic _logic;


        public HostController(ILogger<HostController> logger, IHostLogic logic)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<Host>> GetHost()
        {
            var Hosts = await _logic.GetHosts();
            return Hosts;
        }

        [HttpGet("{id}")]
        public async Task<Host> GetHostById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var history = await _logic.GetHostById(id);
            if (history == null)
            {
                throw new ArgumentException($"Host with ID '{id}' not found");
            }
            return history;
        }

        [HttpPost]
        public async Task<Host> CreateHost(Host history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(nameof(history));
            }
            await _logic.PostHost(history);
            return history;
        }


        [HttpPut("{id}")]
        public async Task<Host> UpdateHost(string id, Host Host)
        {
            if (Host == null)
            {
                throw new ArgumentNullException(nameof(Host));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (Host.id != id)
            {
                throw new ArgumentException($"The ID of the Host in the body '{Host.id}' does not match the ID '{id}' in the URL");
            }
            await _logic.UpdateHost(Host);
            return Host;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHost(string id)
        {
            //var Host = await _dynamoDBContext.LoadAsync<Host>(id);
            var history = await _logic.GetHostById(id);
            if (history == null)
            {
                throw new ArgumentException($"Host with ID '{id}' not found");
            }
            await _logic.DeleteHost(history);
            return Ok();
        }
    }
}
