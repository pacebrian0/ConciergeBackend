using ConciergeBackend.Controllers.Interfaces;
using ConciergeBackend.Logic.Interfaces;
using ConciergeBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConciergeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<Reservation> GetReservationById(int id)
        {

            var res = await _logic.GetReservationById(id);
            if (res == null)
            {
                throw new ArgumentException($"Reservation with ID '{id}' not found");
            }
            return res;
        }

        [HttpGet("user/{userID}")]
        public async Task<IEnumerable<Reservation>> GetReservationsByUser(int userID)
        {


            var res = await _logic.GetReservationsByUser(userID);
            if (res == null)
            {
                throw new ArgumentException($"Reservation with user ID '{userID}' not found");
            }
            return res;
        }

        [HttpPost]
        public async Task<Reservation> CreateReservation(ReservationPost res)
        {
            if (res == null)
            {
                throw new ArgumentNullException(nameof(res));
            }
            var dbRes = new Reservation { 
                id = 0,
                roomID = res.roomID,
                userID = res.userID,
                expiresYN = res.expiresYN,
                expiryDate = res.ExpiryDate,
                reservationCode = "",
                createdBy = res.createdBy,
                modifiedBy = res.createdBy,
                createdOn = DateTime.UtcNow,
                modifiedOn = DateTime.UtcNow,
                status = "A",
                isActive = true,
                reservationDate = res._ReservationDate
            
            };
            await _logic.PostReservation(dbRes);
            return dbRes;
        }


        [HttpPut("{id}")]
        public async Task<Reservation> UpdateReservation(ReservationPut res)
        {
            if (res == null)
            {
                throw new ArgumentNullException(nameof(res));
            }

            var dbRes = await _logic.GetReservationById(res.id);

            dbRes.expiryDate = res.ExpiryDate;
            dbRes.expiresYN = res.expiresYN;
            dbRes.roomID = res.roomID;
            dbRes.userID = res.userID;
            dbRes.modifiedBy = res.modifiedBy;
            dbRes.modifiedOn = DateTime.UtcNow;
            dbRes.reservationDate = res._ReservationDate;

            await _logic.UpdateReservation(dbRes);
            return dbRes;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            //var Reservation = await _dynamoDBContext.LoadAsync<Reservation>(id);
            var res = await _logic.GetReservationById(id);
            if (res == null)
            {
                throw new ArgumentException($"Reservation with ID '{id}' not found");
            }
            await _logic.DeleteReservation(res);
            return Ok();
        }
    }
}