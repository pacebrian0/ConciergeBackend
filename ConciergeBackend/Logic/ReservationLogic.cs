using ConciergeBackend.Data.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;

namespace ConciergeBackend.Logic
{
    public class ReservationLogic : IReservationLogic
    {
        private readonly IReservationData _data;

        public ReservationLogic(IReservationData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            // no need for AWS logic
            return await _data.GetReservations();

        }
        public async Task<Reservation> GetReservationById(string id)
        {
            // no need for AWS logic
            return await _data.GetReservationById(id);

        }

        public async Task PostReservation(Reservation audit)
        {
            //do AWS logic

            //do local logic
            await _data.PostReservation(audit, true);
        }

        public async Task UpdateReservation(Reservation audit)
        {
            //do AWS logic

            //do local logic
            await _data.UpdateReservation(audit, true);
        }

        public async Task DeleteReservation(Reservation audit)
        {
            //do AWS logic

            //do local logic
            await _data.DeleteReservation(audit, true);
        }
    }
}
