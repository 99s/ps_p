using System;
using System.Collections.Generic;

namespace PS_Portal_Api.Models
{
    public partial class AdditionalDataTbl
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Data { get; set; }
    }
}
