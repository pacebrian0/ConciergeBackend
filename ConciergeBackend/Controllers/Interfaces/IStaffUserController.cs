using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IStaffUserController
    {
        void DeleteStaffUser(int id);
        Task<IEnumerable<StaffUser>> GetStaffUserAsync();
        string GetStaffUserById(int id);
        void PostStaffUser([FromBody] StaffUser staffUser);
        void PutStaffUser(int id, [FromBody] StaffUser staffUser);
    }
}