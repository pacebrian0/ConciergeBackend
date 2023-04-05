namespace ConciergeBackend.Models
{

    public class Room
    {
        public string id { get; set; }
        public string name { get; set; }
        public Property property { get; set; }
        public string createdOn { get; set; }
        public string createdBy { get; set; }
        public string modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public bool isActive { get; set; }
        public string status { get; set; }
    }
}
