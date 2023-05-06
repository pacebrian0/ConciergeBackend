using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class SyncData : BaseDatabase, ISyncData
    {
        public SyncData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Sync>> GetSyncs()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.SYNCTABLE
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    var sync = await conn.QueryAsync<Sync>(sql);
                    return sync;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Sync> GetSyncById(int id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.SYNCTABLE
                                    WHERE id=:id
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    var sync = await conn.QueryFirstOrDefaultAsync<Sync>(sql, new {id});
                    return sync;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostSync(Sync sync, bool local)
        {
            try
            {
                const string sql = @"INSERT INTO `conciergedb`.`Synctable`
                    (
                    `timestamp`,
                    `action`,
                    `table_name`,
                    `field_name`,
                    `row_id`)
                    VALUES
                    (
                    :timestamp,
                    :action,
                    :table_name,
                    :field_name,
                    :row_id);
                    ";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { sync.timestamp, sync.action, sync.table, sync.field, sync.rowID });
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task UpdateSync(Sync sync, bool local)
        {
            try
            {
                const string sql = @"
                    UPDATE `conciergedb`.`Synctable`
                    SET
                    `timestamp` = :timestamp,
                    `action` = :action,
                    `table_name` = :table,
                    `field_name` = :field,
                    `row_id` = :rowID
                    WHERE `id` = :id;
";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { sync.timestamp, sync.action, sync.table, sync.field, sync.rowID, sync.id });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
