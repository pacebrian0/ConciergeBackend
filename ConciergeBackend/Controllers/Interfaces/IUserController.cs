using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IUserController
    {
        //Task<User> CreateUser(User history);
        Task<IActionResult> DeleteUser(int id);
        Task<IEnumerable<User>> GetUser();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(UserPut User);
    }
}