using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IUserLogic
    {
        Task DeleteUser(User audit);
        Task<User> GetUserById(string id);
        Task<IEnumerable<User>> GetUsers();
        Task PostUser(User audit);
        Task UpdateUser(User audit);
    }
}