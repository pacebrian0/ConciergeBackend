using ConciergeBackend.Controllers.Interfaces;
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

        public ReservationController(ILogger<ReservationController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IEnumerable<Reservation>> GetReservationAsync()
        {
            var Reservations = new List<Reservation>();
            return Reservations;
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public string GetReservationById(int id)
        {
            return "value";
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void PostReservation([FromBody] Reservation reservation)
        {
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void PutReservation(int id, [FromBody] Reservation reservation)
        {
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void DeleteReservation(int id)
        {
        }
    }
}