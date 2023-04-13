using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase, IHistoryController
    {
        private readonly ILogger<HistoryController> _logger;

        public HistoryController( ILogger<HistoryController> logger)
        {
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IEnumerable<History>> GetHistory()
        {
            var Historys = new List<History>();
            return Historys;
        }

        [HttpGet("{id}")]
        public async Task<History> GetHistoryById(string id)
        {
            var History = new History();
            if (History == null)
            {
                throw new ArgumentException($"History with ID '{id}' not found");
            }
            return History;
        }

        [HttpPost]
        public async Task<History> CreateHistory(History History)
        {
            if (History == null)
            {
                throw new ArgumentNullException(nameof(History));
            }
            //await _dynamoDBContext.SaveAsync(History);
            return History;
        }

        [HttpPut("{id}")]
        public async Task<History> UpdateHistory(string id, History History)
        {
            if (History == null)
            {
                throw new ArgumentNullException(nameof(History));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (History.id != id)
            {
                throw new ArgumentException($"The ID of the History in the body '{History.id}' does not match the ID '{id}' in the URL");
            }
            //await _dynamoDBContext.SaveAsync(History);
            return History;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistory(string id)
        {
            //var History = await _dynamoDBContext.LoadAsync<History>(id);
            var History = new History();
            if (History == null)
            {
                throw new ArgumentException($"History with ID '{id}' not found");
            }
            //await _dynamoDBContext.DeleteAsync(History);
            return NoContent();
        }
    }
}