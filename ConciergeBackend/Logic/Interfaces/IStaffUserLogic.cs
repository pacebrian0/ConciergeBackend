using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IStaffUserLogic
    {
        Task DeleteStaffUser(StaffUser audit);
        Task<StaffUser> GetStaffUserById(int id);
        Task<IEnumerable<StaffUser>> GetStaffUsers();
        Task PostStaffUser(StaffUser audit);
        Task UpdateStaffUser(StaffUser audit);
    }
}