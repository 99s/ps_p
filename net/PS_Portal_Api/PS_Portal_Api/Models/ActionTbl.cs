using System;
using System.Collections.Generic;

namespace PS_Portal_Api.Models
{
    public partial class ActionTbl
    {
        public long Id { get; set; }
        public string? ActionTakenBy { get; set; }
        public string? WhichActionTaken { get; set; }
        public DateTime? TimeOfAction { get; set; }
        public string? DrNo { get; set; }
        public string? IpcCrpcSection { get; set; }
        public long? EvidenceDocFk { get; set; }
        public string? AutharityName { get; set; }
        public long? ComplaintIdFk { get; set; }
        
    }
}
