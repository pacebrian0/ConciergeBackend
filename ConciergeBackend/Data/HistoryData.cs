using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class HistoryData : IHistoryData
    {
        private readonly MySqlConnection _connection;

        public HistoryData(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<History>> GetHistories()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.HISTORY
                                    ";
                using (var conn = _connection)
                {
                    return await conn.QueryAsync<History>(sql);
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<string> PostHistory(History history)
        {
            try
            {
                const string sql = @"INSERT INTO conciergedb.AUDIT 
                                        (awsID, userID, timestamp, table_name, field_name, action, old_value, new_value, comments)
                                    VALUES
                                        (:AWSID, :USERID, :TIMESTAMP, :TABLENAME, :FIELDNAME, :ACTION, :OLDVALUE, :NEWVALUE, :COMMENTS);
                                    
                                    SELECT LAST_INSERT_ID();";
                using (var conn = _connection)
                {
                    return await conn.ExecuteScalarAsync<string>(sql);
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
