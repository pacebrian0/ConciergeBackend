namespace ConciergeBackend.Models
{
    public class User
    {
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public string passwordHash { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string createdOn { get; set; } = string.Empty;
        public string createdBy { get; set; } = string.Empty;
        public string modifiedOn { get; set; } = string.Empty;
        public string modifiedBy { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
    } 
}
