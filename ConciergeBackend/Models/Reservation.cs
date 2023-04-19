namespace ConciergeBackend.Models
{
    public class Reservation
    {
        public string id { get; set; }
        public Room room { get; set; }
        public string userID { get; set; }
        public bool expiresYN { get; set; }
        public string expiryDate { get; set; }
        public string reservationCode { get; set; }
        public string createdOn { get; set; }
        public string createdBy { get; set; }
        public string modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public string status { get; set; }
        public bool isActive { get; set; }
    }
}
