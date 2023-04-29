using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IUserController
    {
        //Task<User> CreateUser(User history);
        Task<IActionResult> DeleteUser(string id);
        Task<IEnumerable<User>> GetUser();
        Task<User> GetUserById(string id);
        Task<User> UpdateUser(string id, User User);
    }
}