using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IPropertyController
    {
        Task<Property> CreateProperty(Property history);
        Task<IActionResult> DeleteProperty(string id);
        Task<IEnumerable<Property>> GetProperty();
        Task<Property> GetPropertyById(string id);
        Task<Property> UpdateProperty(string id, Property Property);
    }
}