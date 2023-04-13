using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IUserController
    {
        void DeleteUser(int id);
        Task<IEnumerable<User>> GetUserAsync();
        string GetUserById(int id);
        void PostUser([FromBody] User user);
        void PutUser(int id, [FromBody] User user);
    }
}