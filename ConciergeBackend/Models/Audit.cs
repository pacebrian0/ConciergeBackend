﻿using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ConciergeBackend.Models
{
    public class Audit
    {
        public int id { get; set; }
        public int userID { get; set; }
        public DateTime timestamp { get; set; }
        public string table { get; set; }
        public string field { get; set; }
        public string action { get; set; }
        public string oldvalue { get; set; }
        public string newvalue { get; set; }
        public string comments { get; set; }
    }


}
