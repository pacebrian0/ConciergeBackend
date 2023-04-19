using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
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
        private readonly IHistoryLogic _logic;


        public HistoryController(ILogger<HistoryController> logger, IHistoryLogic logic)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<History>> GetHistory()
        {
            var Historys = await _logic.GetHistorys();
            return Historys;
        }

        [HttpGet("{id}")]
        public async Task<History> GetHistoryById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var history = await _logic.GetHistoryById(id);
            if (history == null)
            {
                throw new ArgumentException($"History with ID '{id}' not found");
            }
            return history;
        }

        [HttpPost]
        public async Task<History> CreateHistory(History history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(nameof(history));
            }
            await _logic.PostHistory(history);
            return history;
        }

        /*
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
            await _logic.update(History);
            return History;
        }
        */

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistory(string id)
        {
            //var History = await _dynamoDBContext.LoadAsync<History>(id);
            var history = await _logic.GetHistoryById(id);
            if (history == null)
            {
                throw new ArgumentException($"History with ID '{id}' not found");
            }
            await _logic.DeleteHistory(history);
            return Ok();
        }
    }
}