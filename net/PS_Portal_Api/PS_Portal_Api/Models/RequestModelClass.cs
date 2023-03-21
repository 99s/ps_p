namespace PS_Portal_Api.Models
{
    public class RequestModelClass
    {
        public long RequestId { get; set; }
        public string RequestName { get; set; } = string.Empty;
        public string RequestType { get; set; } = string.Empty;

        public string RequestData { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        public string LoginName { get; set; }

        public string LoginPassword { get; set; }
    }

    public class RegistrationRequest
    {
        public string LoginName { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int Usertype { get; set; }
    }

    public class ComplaintViewRequest
    {
        public int Usertype { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string? ComplainNo { get; set; }

        public string? Gd_No { get; set; }
    }

    public class ComplainRequest
    {

        public string? GdNo { get; set; }
        public string? ComplainNo { get; set; }
        public bool IsGd { get; set; }

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



    }

    public class ActionRequest
    {

        public string? ActionTakenBy { get; set; }
        public string? WhichActionTaken { get; set; }
        public DateTime? TimeOfAction { get; set; }
        public string? DrNo { get; set; }
        public string? IpcCrpcSection { get; set; }
        public long? EvidenceDocFk { get; set; }
        public string? AutharityName { get; set; }
        public long? ComplaintIdFk { get; set; }
        public string? EvidenceDocPathAc { get; set; }



    }

    public class ReplyRequest
    {

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

    public class DocUploadRequest
    {
        public string Docname { get; set; }

       // public FileStream DocFile { get; set; }

        public string DocPath { get; set; }

        //public IFormFile FileUp { get; set; }

        //646962796170726F62686174726F79
    }
}
