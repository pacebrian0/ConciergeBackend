using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase, IPropertyController
    {
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(ILogger<PropertyController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public async Task<IEnumerable<Property>> GetPropertyAsync()
        {
            var Propertys = new List<Property>();
            return Propertys;
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public string GetPropertyById(int id)
        {
            return "value";
        }

        // POST api/<PropertyController>
        [HttpPost]
        public void PostProperty([FromBody] Property property)
        {
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public void PutProperty(int id, [FromBody] Property property)
        {
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void DeleteProperty(int id)
        {
        }
    }
}

