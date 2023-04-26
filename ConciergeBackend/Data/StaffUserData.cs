using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class StaffUserData : BaseDatabase, IStaffUserData
    {
        public StaffUserData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<StaffUser>> GetStaffUsers()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.STAFFUSER
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryAsync<StaffUser>(sql);

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<StaffUser> GetStaffUserById(string id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.STAFFUSER
                                    WHERE id=@id
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<StaffUser>(sql, new { id });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostStaffUser(StaffUser staffuser, bool local)
        {
            try
            {
                const string sql = @"
                          INSERT INTO `conciergedb`.`StaffUser`
                            (
                            `name`,
                            `surname`,
                            `propertyID`,
                            `email`,
                            `createdOn`,
                            `createdBy`,
                            `modifiedOn`,
                            `modifiedBy`,
                            `status`)
                            VALUES
                            (
                            @name,
                            @surname ,
                            @propertyID,
                            @email ,
                            now(),
                            @createdBy ,
                            now(),
                            @modifiedBy ,
                            'A' );

                            ";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { staffuser.name, staffuser.surname, staffuser.propertyID, staffuser.email, staffuser.createdBy, staffuser.modifiedBy });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }



        public async Task UpdateStaffUser(StaffUser staffuser, bool local)
        {
            try
            {
                const string sql = @"
                            UPDATE `conciergedb`.`STAFFUSER`
                            SET `name` = @name,
                                `surname` = @surname,
                                `propertyID` = @propertyID,
                                `email` = @email,
                                `modifiedOn` = now(),
                                `modifiedBy` = @modifiedBy,
                                `status` = @status
                            WHERE id = @id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { staffuser.name, staffuser.surname, staffuser.propertyID, staffuser.email, staffuser.modifiedBy, staffuser.status, staffuser.id });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task DeleteStaffUser(StaffUser staffuser, bool local)
        {
            try
            {
                const string sql = @"
                            DELETE FROM `conciergedb`.`STAFFUSER`
                            WHERE id = @id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { staffuser.id });
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
