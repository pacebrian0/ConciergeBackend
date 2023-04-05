namespace ConciergeBackend.Models
{
    public class StaffUser
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Property property { get; set; }
        public string email { get; set; }
        public string createdOn { get; set; }
        public string createdBy { get; set; }
        public string modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public bool isActive { get; set; }
        public string status { get; set; }
    }
}
