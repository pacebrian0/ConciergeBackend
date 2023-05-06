namespace ConciergeBackend.Models
{

    public class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public int propertyID { get; set; }
        public string createdOn { get; set; }
        public string createdBy { get; set; }
        public string modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public string status { get; set; }
    }

    public class RoomPost
    {
        public string name { get; set; }
        public int propertyID { get; set; }
        public string createdBy { get; set; }

    }

    public class RoomPut
    {
        public int id { get; set; }
        public string name { get; set; }
        public int propertyID { get; set; }
        public string modifiedBy { get; set; }
        public string status { get; set; }
    }
}
