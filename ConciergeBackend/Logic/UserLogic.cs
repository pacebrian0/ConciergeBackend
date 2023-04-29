using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;

namespace ConciergeBackend.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserData _data;

        public UserLogic(IUserData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            // no need for AWS logic
            return await _data.GetUsers();

        }
        public async Task<User> GetUserById(string id)
        {
            // no need for AWS logic
            return await _data.GetUserById(id);

        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _data.GetUserByEmail(email);
        }

        public async Task PostUser(User audit)
        {
            //do AWS logic

            //do local logic
            await _data.PostUser(audit, true);
        }

        public async Task UpdateUser(User audit)
        {
            //do AWS logic

            //do local logic
            await _data.UpdateUser(audit, true);
        }

        public async Task DeleteUser(User audit)
        {
            //do AWS logic

            //do local logic
            await _data.DeleteUser(audit, true);
        }
    }
}
