namespace ConciergeBackend.Models
{
    public class Sync
    {
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public string table { get; set; }
        public string field { get; set; }
        public string action { get; set; }
        public int rowID { get; set; }
    }
}
