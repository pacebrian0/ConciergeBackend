using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IPropertyData
    {
        Task DeleteProperty(Property property, bool local);
        Task<Property> GetPropertyById(int id);
        Task<IEnumerable<Property>> GetPropertys();
        Task PostProperty(Property property, bool local);
        Task UpdateProperty(Property property, bool local);
    }
}
