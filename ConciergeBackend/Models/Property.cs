namespace ConciergeBackend.Models
{
    public class Property
    {
        public int id { get; set; }
        public string name { get; set; }
        public string createdOn { get; set; }
        public string createdBy { get; set; }
        public string modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public string status { get; set; }
        public bool isActive { get; set; }
        public int hostID { get; set; }
    }

    public class PropertyPost
    {
        public string name { get; set; }
        public string createdBy { get; set; }
        public string modifiedBy { get; set; }
        public int hostID { get; set; }
    }

    public class PropertyPut
    {
        public int id { get; set; }
        public string name { get; set; }
        public string modifiedBy { get; set; }
        public string status { get; set; }
        public bool isActive { get; set; }
        public int hostID { get; set; }
    }
}
