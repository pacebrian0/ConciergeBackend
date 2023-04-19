using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IStaffUserController
    {
        Task<StaffUser> CreateStaffUser(StaffUser history);
        Task<IActionResult> DeleteStaffUser(string id);
        Task<IEnumerable<StaffUser>> GetStaffUser();
        Task<StaffUser> GetStaffUserById(string id);
        Task<StaffUser> UpdateStaffUser(string id, StaffUser StaffUser);
    }
}