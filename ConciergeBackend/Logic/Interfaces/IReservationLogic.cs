using ConciergeBackend.Models;

namespace ConciergeBackend.Logic.Interfaces
{
    public interface IReservationLogic
    {
        Task DeleteReservation(Reservation audit);
        Task<Reservation> GetReservationById(string id);
        Task<IEnumerable<Reservation>> GetReservations();
        Task PostReservation(Reservation audit);
        Task UpdateReservation(Reservation audit);
        Task<IEnumerable<Reservation>> GetReservationsByUser(string userID);
    }
}