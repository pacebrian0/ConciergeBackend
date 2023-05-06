using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;

namespace ConciergeBackend.Logic
{
    public class StaffUserLogic : IStaffUserLogic
    {
        private readonly IStaffUserData _data;

        public StaffUserLogic(IStaffUserData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<StaffUser>> GetStaffUsers()
        {
            // no need for AWS logic
            return await _data.GetStaffUsers();

        }
        public async Task<StaffUser> GetStaffUserById(int id)
        {
            // no need for AWS logic
            return await _data.GetStaffUserById(id);

        }

        public async Task PostStaffUser(StaffUser audit)
        {
            //do AWS logic

            //do local logic
            await _data.PostStaffUser(audit, true);
        }

        public async Task UpdateStaffUser(StaffUser audit)
        {
            //do AWS logic

            //do local logic
            await _data.UpdateStaffUser(audit, true);
        }

        public async Task DeleteStaffUser(StaffUser audit)
        {
            //do AWS logic

            //do local logic
            await _data.DeleteStaffUser(audit, true);
        }
    }
}
