using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<Property> GetPropertyById(int id)
        {

            var history = await _logic.GetPropertyById(id);
            if (history == null)
            {
                throw new ArgumentException($"Property with ID '{id}' not found");
            }
            return history;
        }

        [HttpPost]
        public async Task<Property> CreateProperty(PropertyPost property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            var dbProp = new Property {
                id = 0,
                name = property.name,
                createdOn = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:sszzz"),
                modifiedOn  = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:sszzz"),
                createdBy = property.createdBy,
                modifiedBy = property.createdBy,
                status = "A",
                isActive = true,
                hostID = property.hostID

            };

            await _logic.PostProperty(dbProp);
            return dbProp;
        }


        [HttpPut("{id}")]
        public async Task<Property> UpdateProperty(PropertyPut property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            var dbProp = await _logic.GetPropertyById(property.id);
            dbProp.modifiedOn = DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss");
            dbProp.name = property.name;
            dbProp.status = property.status;
            dbProp.isActive = property.isActive;
            dbProp.hostID = property.hostID;

            await _logic.UpdateProperty(dbProp);
            return dbProp;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
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

