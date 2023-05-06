using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;

namespace ConciergeBackend.Logic
{
    public class PropertyLogic : IPropertyLogic
    {
        private readonly IPropertyData _data;

        public PropertyLogic(IPropertyData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<Property>> GetPropertys()
        {
            // no need for AWS logic
            return await _data.GetPropertys();

        }
        public async Task<Property> GetPropertyById(int id)
        {
            // no need for AWS logic
            return await _data.GetPropertyById(id);

        }

        public async Task PostProperty(Property audit)
        {
            //do AWS logic

            //do local logic
            await _data.PostProperty(audit, true);
        }

        public async Task UpdateProperty(Property audit)
        {
            //do AWS logic

            //do local logic
            await _data.UpdateProperty(audit, true);
        }

        public async Task DeleteProperty(Property audit)
        {
            //do AWS logic

            //do local logic
            await _data.DeleteProperty(audit, true);
        }
    }
}
