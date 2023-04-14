using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class AuditData : BaseDatabase, IAuditData
    {

        public AuditData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Audit>> GetAudits()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.AUDIT
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    var audit = conn.Query<Audit>(sql);
                    return audit;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostAudit(Audit audit, bool local)
        {
            try
            {
                const string sql = @"INSERT INTO conciergedb.AUDIT 
                                        (awsID, userID, timestamp, table_name, field_name, action, old_value, new_value, comments)
                                    VALUES
                                        (:AWSID, :USERID, :TIMESTAMP, :TABLENAME, :FIELDNAME, :ACTION, :OLDVALUE, :NEWVALUE, :COMMENTS);
                                    
                                    ";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql);
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
