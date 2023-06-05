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
        public async Task<History> GetHistoryById(int id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.HISTORY
                                    WHERE id=@id
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

        public async Task<History> GetHistoryByReservation(int resID)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.HISTORY
                                    WHERE reservationID=@resID
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<History>(sql, new { resID });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task<History> GetHistoryByRoom(int roomID)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.HISTORY
                                    WHERE roomID=@roomID
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<History>(sql, new { roomID });

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
                            @roomID,
                            @reservationID,
                            @userID,
                            UTC_TIMESTAMP()
                            )";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { history.roomID, history.reservationID, history.userID });
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
                            WHERE id = @id";
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
