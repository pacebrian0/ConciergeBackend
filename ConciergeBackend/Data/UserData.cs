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
                const string sql = @"SELECT `user`.`id`,
                                        `user`.`name`,
                                        `user`.`surname`,
                                        `user`.`email`,
                                        `user`.`createdOn`,
                                        `user`.`createdBy`,
                                        `user`.`modifiedOn`,
                                        `user`.`modifiedBy`,
                                        `user`.`password_hash` as passwordHash
                                    FROM `conciergedb`.`user`
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
        public async Task<User> GetUserById(int id)
        {
            try
            {
                const string sql = @"SELECT `user`.`id`,
                                        `user`.`name`,
                                        `user`.`surname`,
                                        `user`.`email`,
                                        `user`.`createdOn`,
                                        `user`.`createdBy`,
                                        `user`.`modifiedOn`,
                                        `user`.`modifiedBy`,
                                        `user`.`password_hash` as passwordHash
                                    FROM `conciergedb`.`user`
                                    WHERE id=@id
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

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                const string sql = @"SELECT `user`.`id`,
                                        `user`.`name`,
                                        `user`.`surname`,
                                        `user`.`email`,
                                        `user`.`createdOn`,
                                        `user`.`createdBy`,
                                        `user`.`modifiedOn`,
                                        `user`.`modifiedBy`,
                                        `user`.`password_hash` as passwordHash
                                    FROM `conciergedb`.`user`
                                    WHERE email=@email
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<User>(sql, new { email });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<int> PostUser(User user, bool local)
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
                            `modifiedBy`,
                            `password_hash`)
                            VALUES
                            (
                            @name,
                            @surname,
                            @email,
                            UTC_TIMESTAMP(),
                            0,
                            UTC_TIMESTAMP(),
                            0,
                            @passwordHash); 
                            SELECT id from `conciergedb`.`User` where email = @email;";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    return await conn.ExecuteScalarAsync<int>(sql, new { user.name, user.surname, user.email, user.passwordHash });
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
                            SET `name` = @name,
                                `surname` = @surname,
                                `email` = @email,
                                `modifiedOn` = UTC_TIMESTAMP(),
                                `modifiedBy` = 0
                            WHERE id = @id";
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
                            WHERE id = @id";
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
