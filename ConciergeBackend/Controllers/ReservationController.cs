using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase, IReservationController
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationLogic _logic;


        public ReservationController(ILogger<ReservationController> logger, IReservationLogic logic)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));
        }

        [HttpGet]
        public async Task<IEnumerable<Reservation>> GetReservation()
        {
            var Reservations = await _logic.GetReservations();
            return Reservations;
        }

        [HttpGet("{id}")]
        public async Task<Reservation> GetReservationById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var history = await _logic.GetReservationById(id);
            if (history == null)
            {
                throw new ArgumentException($"Reservation with ID '{id}' not found");
            }
            return history;
        }

        [HttpPost]
        public async Task<Reservation> CreateReservation(Reservation history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(nameof(history));
            }
            await _logic.PostReservation(history);
            return history;
        }


        [HttpPut("{id}")]
        public async Task<Reservation> UpdateReservation(string id, Reservation Reservation)
        {
            if (Reservation == null)
            {
                throw new ArgumentNullException(nameof(Reservation));
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (Reservation.id != id)
            {
                throw new ArgumentException($"The ID of the Reservation in the body '{Reservation.id}' does not match the ID '{id}' in the URL");
            }
            await _logic.UpdateReservation(Reservation);
            return Reservation;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            //var Reservation = await _dynamoDBContext.LoadAsync<Reservation>(id);
            var history = await _logic.GetReservationById(id);
            if (history == null)
            {
                throw new ArgumentException($"Reservation with ID '{id}' not found");
            }
            await _logic.DeleteReservation(history);
            return Ok();
        }
    }
}