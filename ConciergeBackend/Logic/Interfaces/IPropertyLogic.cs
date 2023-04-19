using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IPropertyLogic
    {
        Task DeleteProperty(Property audit);
        Task<Property> GetPropertyById(string id);
        Task<IEnumerable<Property>> GetPropertys();
        Task PostProperty(Property audit);
        Task UpdateProperty(Property audit);
    }
}