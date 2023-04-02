using System;
using System.Collections.Generic;

namespace PS_Portal_Api.Models
{
    public partial class ReplyTbl
    {
        public long Id { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string? CaseReferenceNo { get; set; }
        public string? AuthorityName { get; set; }
        public string? AuthorityAddress { get; set; }
        public string? ReplyGist { get; set; }
        public string? DrNo { get; set; }
        public long? EvidenceDocIdFk { get; set; }
        public long? ComplaintIdFk { get; set; }
        public string? SuspectStatus { get; set; }
        public string? CourtOrder { get; set; }
        public string? Status { get; set; }
        public string? CourtNameAddress { get; set; }
        public string? OrderNo { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public string? OrderGistCourt { get; set; }
        public long? OrderCopyDocFk { get; set; }
    }
}
