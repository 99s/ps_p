namespace PS_Portal_Api.Models
{
    public class ResponseModelClass
    {
        public string? Message { get; set; }

        public bool Success { get; set; }

        public dynamic? DefaultData { get; set; }
    }

    public class LoginResponse : ResponseModelClass
    {
        public string? LoginName { get; set; }

    }

    public class RegistrationResponse : ResponseModelClass
    {
        public string? LoginName { get; set; }

        public string? Name { get; set; }

    }

    public class MultiComplainResponse : ResponseModelClass
    {
        public List<ComplainTable>? ComplainResponses { get; set; }

    }

    public class SingleComplainResponse : ResponseModelClass
    {


        public  ComplainTable? Complain { get; set;}

        public List<DocsTbl>? Docs { get; set; }

        public List<ReplyTbl>? Replies { get; set; }

        public List<ActionTbl>? Actions { get; set; }
    }

    public class ReplyTblResponse : ResponseModelClass
    {
        public List<ReplyTbl>? Replies { get; set; }

        public List<DocsTbl>? Docs { get; set; }
    }

    public class ActionTblResponse : ResponseModelClass
    {
        public List<ActionTbl>? Actions { get; set; }
        public List<DocsTbl>? Docs { get; set; }
    }

    public class AdditionalDataTableResponse : ResponseModelClass
    {
        public List<AdditionalDataTbl>? AdditionalDataTbls { get; set; }
    }

    public class DocsTableSingleResponse : ResponseModelClass
    {
        public DocsTbl? Doc { get; set; }
    }

}
