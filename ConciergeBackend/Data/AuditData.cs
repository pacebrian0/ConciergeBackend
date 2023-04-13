using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class AuditData : BaseDatabase,IAuditData
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
                using (var conn = new MySqlConnection(_localConn) )
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
            var id = "";
            try
            {
                const string sql = @"
                            INSERT INTO `conciergedb`.`Audit`
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
                            :USERID,
                            current_timestamp(),
                            :TABLENAME,
                            :FIELDNAME, 
                            :ACTION, 
                            :OLDVALUE, 
                            :NEWVALUE, 
                            :COMMENTS);";
               using (var conn = new MySqlConnection(_localConn) )
                {
                    await conn.ExecuteAsync(sql, new {USERID= audit.userID, TIMESTAMP= audit.timestamp, TABLENAME=audit.table, FIELDNAME=audit.field, OLDVALUE=audit.oldvalue, NEWVALUE=audit.newvalue, COMMENTS=audit.comments});
                }
               
               /*
                using (var conn = new MySqlConnection(_remoteConn))
                {
                    id= await conn.ExecuteScalarAsync<string>(sql, new { USERID = audit.userID, TABLENAME = audit.table, FIELDNAME = audit.field, OLDVALUE = audit.oldvalue, NEWVALUE = audit.newvalue, COMMENTS = audit.comments });
                }
               */

                return "1";
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Audit> GetAuditById(string id)
        {
            try
            {
                const string sql = @"SELECT * FROM conciergedb.AUDIT 
                                     WHERE id = :ID";
                using (var conn = new MySqlConnection(_localConn) )
                {
                    return await conn.QueryFirstAsync<Audit>(sql, new { ID = id });
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Audit> UpdateAudit(string id, Audit audit)
        {
            try
            {
                const string sql = @"SELECT * FROM conciergedb.AUDIT 
                                     WHERE id = :ID";
                using (var conn = new MySqlConnection(_localConn) )
                {
                    return await conn.QueryFirstAsync<Audit>(sql, new { ID = id });
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task DeleteAudit(string id)
        {
            try
            {
                const string sql = @"SELECT * FROM conciergedb.AUDIT 
                                     WHERE id = :ID";
                using (var conn = new MySqlConnection(_localConn) )
                {
                     await conn.QueryFirstAsync<Audit>(sql, new { ID = id });
                    
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
