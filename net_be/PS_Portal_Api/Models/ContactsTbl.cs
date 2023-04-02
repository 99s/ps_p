using System;
using System.Collections.Generic;

namespace PS_Portal_Api.Models
{
    public partial class ContactsTbl
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? OfficerName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Extra { get; set; }
        public string? Psname { get; set; }
        public string? District { get; set; }
        public int? Type { get; set; }
    }
}
