using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IUserLogic
    {
        Task DeleteUser(User audit);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<int> PostUser(User audit);
        Task UpdateUser(User audit);
        Task<User> GetUserByEmail(string email);
    }
}