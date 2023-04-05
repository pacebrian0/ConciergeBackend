namespace ConciergeBackend.Models
{
    public class History
    {
        public string id { get; set; }
        public Room room { get; set; }
        public string userID { get; set; }
        public string timestamp { get; set; }
    }
}
