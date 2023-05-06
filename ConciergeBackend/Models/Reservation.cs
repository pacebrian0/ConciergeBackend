using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Globalization;

namespace ConciergeBackend.Models
{
    public class Reservation
    {
        public int id { get; set; }
        public int roomID { get; set; }
        public int userID { get; set; }
        public bool expiresYN { get; set; }
        public DateTime expiryDate { get; set; }
        public string reservationCode { get; set; }
        public DateTime createdOn { get; set; }
        public int createdBy { get; set; }
        public DateTime modifiedOn { get; set; }
        public int modifiedBy { get; set; }
        public string status { get; set; }
        public bool isActive { get; set; }
        public DateTime reservationDate { get; set; }
    }

    public class ReservationPost
    {
        public int roomID { get; set; }
        public int userID { get; set; }
        public bool expiresYN { get; set; }
        public DateTime ExpiryDate;

        public string expiryDate
        {
            get => ExpiryDate.ToString("yyyy-MM-dd HH:mm:sszzz");
            set => ExpiryDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture).ToUniversalTime();
        }

        public int createdBy { get; set; }

        public DateTime _ReservationDate { get; set; }

        public string reservationDate
        {
            get => _ReservationDate.ToString("yyyy-MM-dd HH:mm:sszzz");
            set => _ReservationDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture).ToUniversalTime();
        }

    }

    public class ReservationPut
    {
        public int id { get; set; }
        public int roomID { get; set; }
        public int userID { get; set; }
        public bool expiresYN { get; set; }
        public DateTime ExpiryDate;
        public string expiryDate
        {
            get => ExpiryDate.ToString("yyyy-MM-dd HH:mm:sszzz");
            set => ExpiryDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture).ToUniversalTime();
        }
        public DateTime _ReservationDate { get; set; }

        public string reservationDate
        {
            get => _ReservationDate.ToString("yyyy-MM-dd HH:mm:sszzz");
            set => _ReservationDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:sszzz", CultureInfo.InvariantCulture).ToUniversalTime();
        }



        public int modifiedBy { get; set; }
    }

}
