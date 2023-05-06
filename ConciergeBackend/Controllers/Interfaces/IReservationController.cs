using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IReservationController
    {
        Task<Reservation> CreateReservation(ReservationPost res);
        Task<IActionResult> DeleteReservation(int id);
        Task<IEnumerable<Reservation>> GetReservation();
        Task<Reservation> GetReservationById(int id);
        Task<Reservation> UpdateReservation(ReservationPut res);
        Task<IEnumerable<Reservation>> GetReservationsByUser(int userID);
    }
}