using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IUserData
    {
        Task DeleteUser(User user, bool local);
        Task<User> GetUserById(string id);
        Task<IEnumerable<User>> GetUsers();
        Task PostUser(User user, bool local);
        Task UpdateUser(User user, bool local);
    }
}
