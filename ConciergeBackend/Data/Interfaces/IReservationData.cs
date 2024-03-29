﻿using ConciergeBackend.Models;

namespace ConciergeBackend.Data.Interfaces
{
    public interface IReservationData
    {
        Task DeleteReservation(Reservation reservation, bool local);
        Task<Reservation> GetReservationById(int id);
        Task<IEnumerable<Reservation>> GetReservations();
        Task PostReservation(Reservation reservation, bool local);
        Task UpdateReservation(Reservation reservation, bool local);
        Task<IEnumerable<Reservation>> GetReservationsByUser(int userID);
    }
}
