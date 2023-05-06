namespace ConciergeBackend.Models
{
    public class History
    {
        public int id { get; set; }
        public int roomID { get; set; }
        public int reservationID { get; set; }
        public int userID { get; set; }
        public string timestamp { get; set; }
    }

    public class HistoryPost
    {
        public int roomID { get; set; }
        public int reservationID { get; set; }
        public int userID { get; set; }
    }
}
