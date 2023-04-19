using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
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
        private readonly IPropertyLogic _logic;


        public PropertyController(ILogger<PropertyController> logger, IPropertyLogic logic)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<Property>> GetProperty()
        {
            var Propertys = await _logic.GetPropertys();
            return Propertys;
        }

        [HttpGet("{id}")]
        public async Task<Property> GetPropertyById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var history = await _logic.GetPropertyById(id);
            if (history == null)
            {
                throw new ArgumentException($"Property with ID '{id}' not found");
            }
            return history;
        }

        [HttpPost]
        public async Task<Property> CreateProperty(Property history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(nameof(history));
            }
            await _logic.PostProperty(history);
            return history;
        }


        [HttpPut("{id}")]
        public async Task<Property> UpdateProperty(string id, Property Property)
        {
            if (Property == null)
            {
                throw new ArgumentNullException(nameof(Property));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (Property.id != id)
            {
                throw new ArgumentException($"The ID of the Property in the body '{Property.id}' does not match the ID '{id}' in the URL");
            }
            await _logic.UpdateProperty(Property);
            return Property;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(string id)
        {
            //var Property = await _dynamoDBContext.LoadAsync<Property>(id);
            var history = await _logic.GetPropertyById(id);
            if (history == null)
            {
                throw new ArgumentException($"Property with ID '{id}' not found");
            }
            await _logic.DeleteProperty(history);
            return Ok();
        }
    }
}

