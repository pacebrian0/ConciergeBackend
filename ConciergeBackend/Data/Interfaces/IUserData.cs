using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IUserData
    {
        Task DeleteUser(User user, bool local);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<int> PostUser(User user, bool local);
        Task UpdateUser(User user, bool local);
        Task<User> GetUserByEmail(string email);
    }
}
