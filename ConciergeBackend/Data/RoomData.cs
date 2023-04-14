using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class RoomData : BaseDatabase, IRoomData
    {
        public RoomData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.ROOM
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryAsync<Room>(sql);

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Room> GetRoomById(string id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.ROOM
                                    WHERE id=:id
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<Room>(sql, new { id });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostRoom(Room room, bool local)
        {
            try
            {
                const string sql = @"
                          INSERT INTO `conciergedb`.`Room`
                            (
                            `name`,
                            `propertyID`,
                            `createdOn`,
                            `createdBy`,
                            `modifiedOn`,
                            `modifiedBy`,
                            `status`)
                            VALUES
                            (
                            :name,
                            :property,
                            now(),
                            :createdBy,
                            now(),
                            :modifiedBy,
                            'A');
                            ";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { room.name, room.property, room.createdBy, room.modifiedBy });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }



        public async Task UpdateRoom(Room room, bool local)
        {
            try
            {
                const string sql = @"
                            UPDATE `conciergedb`.`ROOM`
                            SET `name` = :name,
                                `propertyID` = :property,
                                `modifiedOn` = now(),
                                `modifiedBy` = :modifiedBy,
                                `status` = :status
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { room.name, room.property, room.modifiedBy, room.status, room.id });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task DeleteRoom(Room room, bool local)
        {
            try
            {
                const string sql = @"
                            DELETE FROM `conciergedb`.`ROOM`
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { room.id });
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
