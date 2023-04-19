using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class PropertyData : BaseDatabase, IPropertyData
    {
        public PropertyData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Property>> GetPropertys()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.PROPERTY
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryAsync<Property>(sql);

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Property> GetPropertyById(string id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.PROPERTY
                                    WHERE id=@id
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<Property>(sql, new { id });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostProperty(Property property, bool local)
        {
            try
            {
                const string sql = @"
                           INSERT INTO `conciergedb`.`PROPERTY`
                            (
                            `name`,
                            `createdOn`,
                            `createdBy`,
                            `modifiedOn`,
                            `modifiedBy`,
                            `status`,
                            `hostID`)
                            VALUES
                            (
                            @name,
                            now(),
                            @createdBy,
                            now(),
                            @modifiedBy,
                            'A',
                            @hostID);

                            ";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { property.name, property.createdBy, property.modifiedBy, property.hostID });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }



        public async Task UpdateProperty(Property property, bool local)
        {
            try
            {
                const string sql = @"
                            UPDATE `conciergedb`.`PROPERTY`
                            SET `name` = @name,
                                `modifiedOn` = now(),
                                `modifiedBy` = @modifiedBy,
                                `status` = @status,
                                `hostID` = @hostID
                            WHERE id = @id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { property.name, property.modifiedBy, property.status, property.hostID, property.id });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task DeleteProperty(Property property, bool local)
        {
            try
            {
                const string sql = @"
                            DELETE FROM `conciergedb`.`PROPERTY`
                            WHERE id = @id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { property.id });
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
