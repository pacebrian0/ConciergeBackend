using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class HistoryData : BaseDatabase, IHistoryData
    {


        public HistoryData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<History>> GetHistories()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.HISTORY
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryAsync<History>(sql);

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task<History> GetHistoryById(string id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.HISTORY
                                    WHERE id=:id
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<History>(sql, new { id });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostHistory(History history, bool local)
        {
            try
            {
                const string sql = @"
                            INSERT INTO `conciergedb`.`History`
                            (
                            `roomID`,
                            `reservationID`,
                            `userID`,
                            `timestamp`)
                            VALUES
                            (
                            :roomID,
                            :reservationID,
                            :userID,
                            now()
                            )";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { history.room, history.reservation, history.userID });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }



        public async Task DeleteHistory(History history, bool local)
        {
            try
            {
                const string sql = @"
                            DELETE FROM `conciergedb`.`HISTORY`
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { history.id });
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
