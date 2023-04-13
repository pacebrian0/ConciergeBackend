using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConciergeBackend.Controllers.Interfaces
{
    public interface IReservationController
    {
        void DeleteReservation(int id);
        Task<IEnumerable<Reservation>> GetReservationAsync();
        string GetReservationById(int id);
        void PostReservation([FromBody] Reservation reservation);
        void PutReservation(int id, [FromBody] Reservation reservation);
    }
}