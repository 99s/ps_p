using System;
using System.Collections.Generic;

namespace PS_Portal_Api.Models
{
    public partial class ComplainTable
    {
        public long Id { get; set; }
        public string? GdNo { get; set; }
        public string? ComplainNo { get; set; }
        public bool IsGd { get; set; }
        public byte[] ComplainDateTime { get; set; } = null!;
        public string? ComplainantName { get; set; }
        public string? VictimName { get; set; }
        public string? ComplainantAddress { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string ComplainNature { get; set; } = null!;
        public string? GistOfTheComplain { get; set; }
        public string? AccusedDetails { get; set; }
        public string? DateTimeOfIncident { get; set; }
        public string? EvidenceDocPath { get; set; }
        public long? EvidenceDocFk { get; set; }
        public DateTime? ComplainTime { get; set; }

        public string? ComplainUpdateTimes { get; set; }
    }
}
