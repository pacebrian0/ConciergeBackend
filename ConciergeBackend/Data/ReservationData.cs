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
                const string sql = @"SELECT `Reservations`.`id`,
                                        `Reservations`.`roomID`,
                                        `Reservations`.`userID`,
                                        `Reservations`.`expiryDate`,
                                        `Reservations`.`reservationDate`,
                                        `Reservations`.`createdOn`,
                                        `Reservations`.`createdBy`,
                                        `Reservations`.`modifiedOn`,
                                        `Reservations`.`modifiedBy`,
                                        `Reservations`.`status`,
                                         insert(
                                            insert(
                                                insert(
                                                insert(hex(`Reservations`.`reservationCode`),9,0,'-'),
                                                14,0,'-'),
                                                19,0,'-'),
                                            24,0,'-') reservationCode
                                    FROM `conciergedb`.`Reservations`;
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
        public async Task<IEnumerable<Reservation>> GetReservationsByUser(int userID)
        {
            try
            {
                const string sql = @"SELECT `Reservations`.`id`,
                                        `Reservations`.`roomID`,
                                        `Reservations`.`userID`,
                                        `Reservations`.`expiryDate`,
                                        `Reservations`.`reservationDate`,
                                        `Reservations`.`createdOn`,
                                        `Reservations`.`createdBy`,
                                        `Reservations`.`modifiedOn`,
                                        `Reservations`.`modifiedBy`,
                                        `Reservations`.`status`,
                                         insert(
                                            insert(
                                                insert(
                                                insert(hex(`Reservations`.`reservationCode`),9,0,'-'),
                                                14,0,'-'),
                                                19,0,'-'),
                                            24,0,'-') reservationCode
                                    FROM `conciergedb`.`Reservations`
                                    WHERE userID=@userID
                                    ";
                using (var conn = new MySqlConnection(_localConn))
                {
                    return await conn.QueryAsync<Reservation>(sql, new { userID });

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<Reservation> GetReservationById(int id)
        {
            try
            {
                const string sql = @"SELECT `Reservations`.`id`,
                                        `Reservations`.`roomID`,
                                        `Reservations`.`userID`,
                                        `Reservations`.`expiryDate`,
                                        `Reservations`.`reservationDate`,
                                        `Reservations`.`createdOn`,
                                        `Reservations`.`createdBy`,
                                        `Reservations`.`modifiedOn`,
                                        `Reservations`.`modifiedBy`,
                                        `Reservations`.`status`,
                                         insert(
                                            insert(
                                                insert(
                                                insert(hex(`Reservations`.`reservationCode`),9,0,'-'),
                                                14,0,'-'),
                                                19,0,'-'),
                                            24,0,'-') reservationCode
                                    FROM `conciergedb`.`Reservations`
                                    WHERE id=@id
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
                                `reservationDate`,
                                `createdOn`,
                                `createdBy`,
                                `modifiedOn`,
                                `modifiedBy`,
                                `status`)
                                VALUES
                                (
                                @roomID ,
                                @userID ,
                                @expiryDate ,
                                @reservationDate,
                                UTC_TIMESTAMP() ,
                                @createdBy ,
                                UTC_TIMESTAMP() ,
                                @modifiedBy ,
                                'A' );
                            ";

                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { reservation.roomID, reservation.userID, reservation.expiryDate, reservation.createdBy, reservation.modifiedBy, reservation.reservationDate });
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
                            UPDATE `conciergedb`.`Reservations`
                            SET `roomID` = @roomID,
                                `userID` = @userID,
                                `expiryDate` = @expiryDate,
                                `modifiedOn` = UTC_TIMESTAMP(),
                                `modifiedBy` = @modifiedBy,
                                `reservationDate` = @reservationDate,
                                `status` = @status
                            WHERE id = @id";
                using (var conn = new MySqlConnection(local ? _localConn : _remoteConn))
                {
                    await conn.ExecuteAsync(sql, new { reservation.roomID, reservation.userID, reservation.expiryDate, reservation.modifiedBy, reservation.status, reservation.id, reservation.reservationDate });
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
                            DELETE FROM `conciergedb`.`Reservations`
                            WHERE id = @id";
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
