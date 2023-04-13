using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IPropertyController
    {
        void DeleteProperty(int id);
        Task<IEnumerable<Property>> GetPropertyAsync();
        string GetPropertyById(int id);
        void PostProperty([FromBody] Property property);
        void PutProperty(int id, [FromBody] Property property);
    }
}