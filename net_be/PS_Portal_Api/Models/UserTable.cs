using System;
using System.Collections.Generic;

namespace PS_Portal_Api.Models
{
    public partial class UserTable
    {
        public long Id { get; set; }
        public long? UserTypeFk { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PasswordHash { get; set; }
        public string? LoginName { get; set; }
    }
}
