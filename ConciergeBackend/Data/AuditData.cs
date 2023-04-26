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
                const string sql = @"INSERT INTO `conciergedb`.`Audit`
                                        (
                                        `userID`,
                                        `timestamp`,
                                        `table_name`,
                                        `field_name`,
                                        `action`,
                                        `old_value`,
                                        `new_value`,
                                        `comments`)
                                        VALUES
                                        (
                                        :userID,
                                        :timestamp,
                                        :table,
                                        :field,
                                        :action,
                                        :oldvalue,
                                        :newvalue,
                                        :comments);

                                    ";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql,new {audit.userID, audit.timestamp, audit.table, audit.field, audit.action, audit.oldvalue, audit.newvalue, audit.comments });
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

       
    }
}
