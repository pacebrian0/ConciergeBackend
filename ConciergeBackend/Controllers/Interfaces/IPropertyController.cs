using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IPropertyController
    {
        Task<Property> CreateProperty(PropertyPost history);
        Task<IActionResult> DeleteProperty(int id);
        Task<IEnumerable<Property>> GetProperty();
        Task<Property> GetPropertyById(int id);
        Task<Property> UpdateProperty(PropertyPut Property);
    }
}