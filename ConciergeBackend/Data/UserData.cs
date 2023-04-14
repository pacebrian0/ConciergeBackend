using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class UserData : BaseDatabase, IUserData
    {
        public UserData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.USER
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryAsync<User>(sql);

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task<User> GetUserById(string id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.USER
                                    WHERE id=:id
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<User>(sql, new { id });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostUser(User user, bool local)
        {
            try
            {
                const string sql = @"
                            INSERT INTO `conciergedb`.`User`
                            (
                            `name`,
                            `surname`,
                            `email`,
                            `createdOn`,
                            `createdBy`,
                            `modifiedOn`,
                            `modifiedBy`)
                            VALUES
                            (
                            :name,
                            :surname,
                            :email,
                            now(),
                            0,
                            now(),
                            0)";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { user.name, user.surname, user.email });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }



        public async Task UpdateUser(User user, bool local)
        {
            try
            {
                const string sql = @"
                            UPDATE `conciergedb`.`User`
                            SET `name` = :name,
                                `surname` = :surname,
                                `email` = :email,
                                `modifiedOn` = now(),
                                `modifiedBy` = 0
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { user.name, user.surname, user.email, user.id });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task DeleteUser(User user, bool local)
        {
            try
            {
                const string sql = @"
                            DELETE FROM `conciergedb`.`User`
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { user.id });
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
