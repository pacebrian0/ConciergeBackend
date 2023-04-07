using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class AuditData
    {
        private readonly MySqlConnection _connection;

        public AuditData(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Audit>> GetAudits()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.AUDIT
                                    ";
                using (var conn = _connection)
                {
                    return await conn.QueryAsync<Audit>(sql);
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<string> PostAudit(Audit audit)
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
