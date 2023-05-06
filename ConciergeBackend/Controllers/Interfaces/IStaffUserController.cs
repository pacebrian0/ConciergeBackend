using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IStaffUserController
    {
        Task<StaffUser> CreateStaffUser(StaffUser history);
        Task<IActionResult> DeleteStaffUser(int id);
        Task<IEnumerable<StaffUser>> GetStaffUser();
        Task<StaffUser> GetStaffUserById(int id);
        Task<StaffUser> UpdateStaffUser(int id, StaffUser StaffUser);
    }
}