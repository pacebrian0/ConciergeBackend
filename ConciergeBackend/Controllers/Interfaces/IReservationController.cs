using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IReservationController
    {
        Task<Reservation> CreateReservation(Reservation history);
        Task<IActionResult> DeleteReservation(string id);
        Task<IEnumerable<Reservation>> GetReservation();
        Task<Reservation> GetReservationById(string id);
        Task<Reservation> UpdateReservation(string id, Reservation Reservation);
    }
}