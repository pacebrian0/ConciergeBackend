using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Host = ConciergeBackend.Models.Host;


namespace ConciergeBackend.Data
{

    public class HostData : BaseDatabase, IHostData
    {
        public HostData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Host>> GetHosts()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.HOST
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryAsync<Host>(sql);

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task<Host> GetHostById(string id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.HOST
                                    WHERE id=:id
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<Host>(sql, new { id });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostHost(Host host, bool local)
        {
            try
            {
                const string sql = @"
                            INSERT INTO `conciergedb`.`HOST`
                            (
                            `name`,
                            `URL`)
                            VALUES
                            (
                            :name,
                            :URL);
                            ";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { host.name, host.URL });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }



        public async Task UpdateHost(Host host, bool local)
        {
            try
            {
                const string sql = @"
                            UPDATE `conciergedb`.`HOST`
                            SET `name` = :name,
                                `url` = :URL
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { host.name, host.id, host.URL });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task DeleteHost(Host host, bool local)
        {
            try
            {
                const string sql = @"
                            DELETE FROM `conciergedb`.`Host`
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { host.id });
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}

