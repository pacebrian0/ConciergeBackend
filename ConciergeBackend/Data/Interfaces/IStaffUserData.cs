using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IStaffUserData
    {
        Task DeleteStaffUser(StaffUser staffuser, bool local);
        Task<StaffUser> GetStaffUserById(string id);
        Task<IEnumerable<StaffUser>> GetStaffUsers();
        Task PostStaffUser(StaffUser staffuser, bool local);
        Task UpdateStaffUser(StaffUser staffuser, bool local);
    }
}
