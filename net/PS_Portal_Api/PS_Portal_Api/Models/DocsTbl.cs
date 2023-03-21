using System;
using System.Collections.Generic;

namespace PS_Portal_Api.Models
{
    public partial class DocsTbl
    {
        public long Id { get; set; }
        public byte[]? DocDate { get; set; }
        public string? DocName { get; set; }
        public string? DocPath { get; set; }

        public DateTime? DocUploadTime { get; set; }
    }
}
