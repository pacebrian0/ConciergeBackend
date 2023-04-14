using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Models;
using Dapper;
using MySqlConnector;

namespace ConciergeBackend.Data
{
    public class ReservationData : BaseDatabase, IReservationData
    {
        public ReservationData(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.RESERVATION
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryAsync<Reservation>(sql);

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Reservation> GetReservationById(string id)
        {
            try
            {
                const string sql = @"SELECT *
                                    FROM conciergedb.RESERVATION
                                    WHERE id=:id
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryFirstOrDefaultAsync<Reservation>(sql, new { id });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task PostReservation(Reservation reservation, bool local)
        {
            try
            {
                const string sql = @"
                           INSERT INTO `conciergedb`.`Reservations`
                                (
                                `roomID`,
                                `userID`,
                                `expiryDate`,
                                `createdOn`,
                                `createdBy`,
                                `modifiedOn`,
                                `modifiedBy`,
                                `status`)
                                VALUES
                                (
                                :room ,
                                :userID ,
                                :expiryDate ,
                                now() ,
                                :createdBy ,
                                now() ,
                                :modifiedBy ,
                                'A' );
                            ";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { reservation.room, reservation.userID, reservation.expiryDate, reservation.createdBy, reservation.modifiedBy });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }



        public async Task UpdateReservation(Reservation reservation, bool local)
        {
            try
            {
                const string sql = @"
                            UPDATE `conciergedb`.`RESERVATION`
                            SET `roomID` = :room,
                                `userID` = :userID,
                                `expiryDate` = :expiryDate,
                                `modifiedOn` = now(),
                                `modifiedBy` = :modifiedBy,
                                `status` = :status
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { reservation.room, reservation.userID, reservation.expiryDate, reservation.modifiedBy, reservation.status, reservation.id });
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task DeleteReservation(Reservation reservation, bool local)
        {
            try
            {
                const string sql = @"
                            DELETE FROM `conciergedb`.`RESERVATION`
                            WHERE id = :id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { reservation.id });
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
