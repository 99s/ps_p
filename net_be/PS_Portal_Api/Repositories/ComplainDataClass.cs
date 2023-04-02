using Microsoft.EntityFrameworkCore;
using PS_Portal_Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace PS_Portal_Api.Repositories
{
    public class ComplainDataClass
    {
        psportal_dbContext context;
        public ComplainDataClass(psportal_dbContext con)
        {
            context = con;
        }


        public async Task<MultiComplainResponse> GetAllComplainData()
        {
            MultiComplainResponse response = new MultiComplainResponse();
            try
            {
                response.Success = true;
                response.ComplainResponses = await (from ad in context.ComplainTables
                                                    select ad).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<SingleComplainResponse> GetSingleComplainData(ComplaintViewRequest request)
        {
            SingleComplainResponse response = new SingleComplainResponse();
            try
            {
                if (string.IsNullOrEmpty(request.ComplainNo))
                {
                    var _v = await (from _complain in context.ComplainTables.AsNoTracking()
                                    join _action in context.ActionTbls.AsNoTracking() on _complain.Id equals _action.ComplaintIdFk into _acLeft
                                    from _action in _acLeft.DefaultIfEmpty()
                                    join _reply in context.ReplyTbls.AsNoTracking() on _complain.Id equals _reply.ComplaintIdFk into _reLeft
                                    from _reply in _reLeft.DefaultIfEmpty()
                                    join _doc1 in context.DocsTbls.AsNoTracking() on _complain.EvidenceDocFk equals _doc1.Id into _doc1left
                                    from _doc1 in _doc1left.DefaultIfEmpty()
                                    join _docRe in context.DocsTbls.AsNoTracking() on _reply.OrderCopyDocFk equals _docRe.Id into _docreleft
                                    from _docRe in _docreleft.DefaultIfEmpty()
                                    join _docAc in context.DocsTbls.AsNoTracking() on _action.EvidenceDocFk equals _docAc.Id into _docAcleft
                                    from _docAc in _docAcleft.DefaultIfEmpty()
                                    where _complain.GdNo == request.Gd_No
                                    select new
                                    {
                                        _complain,
                                        _action,
                                        _reply,
                                        _doc1,
                                        _docRe,
                                        _docAc

                                    }).OrderByDescending(o => o._complain.Id).ToListAsync();

                    response.DefaultData = _v;
                    response.Success = true;

                }
                else
                {
                    var _v = await (from _complain in context.ComplainTables.AsNoTracking()
                                    join _action in context.ActionTbls.AsNoTracking() on _complain.Id equals _action.ComplaintIdFk into _acLeft
                                    from _action in _acLeft.DefaultIfEmpty()
                                    join _reply in context.ReplyTbls.AsNoTracking() on _complain.Id equals _reply.ComplaintIdFk into _reLeft
                                    from _reply in _reLeft.DefaultIfEmpty()
                                    join _doc1 in context.DocsTbls.AsNoTracking() on _complain.EvidenceDocFk equals _doc1.Id into _doc1left
                                    from _doc1 in _doc1left.DefaultIfEmpty()
                                    join _docRe in context.DocsTbls.AsNoTracking() on _reply.OrderCopyDocFk equals _docRe.Id into _docreleft
                                    from _docRe in _docreleft.DefaultIfEmpty()
                                    join _docAc in context.DocsTbls.AsNoTracking() on _action.EvidenceDocFk equals _docAc.Id into _docAcleft
                                    from _docAc in _docAcleft.DefaultIfEmpty()
                                    where _complain.ComplainNo == request.ComplainNo
                                    select new
                                    {
                                        _complain,
                                        _action,
                                        _reply,
                                        _doc1,
                                        _docRe,
                                        _docAc
                                        //  Id = "",
                                        //GdNo = "",
                                        //ComplainNo = "",
                                        //IsGd = "",
                                        //ComplainDateTime = "",
                                        //ComplainantName = "",
                                        //VictimName = "",
                                        //ComplainantAddress = "",
                                        //MobileNo = "",
                                        //EmailId = "",
                                        //ComplainNature = "",

                                        //GistOfTheComplain = "",
                                        //AccusedDetails = "",
                                        //DateTimeOfIncident = "",
                                        //EvidenceDocPath = "",
                                        //EvidenceDocFk = "",
                                        //ComplainTime = "",

                                    }).OrderByDescending(o => o._complain.Id).ToListAsync();

                    response.DefaultData = _v;
                    response.Success = true;
                    //response.Complain = ((ComplainTable?)(from c in context.ComplainTables
                    //                        where c.ComplainNo == request.ComplainNo
                    //                        select c));
                    //response.Actions = ((List<ActionTbl>?)(from c in context.ComplainTables
                    //                    join acn in context.ActionTbls
                    //                    on c.Id equals acn.ComplaintIdFk
                    //                    join
                    //                    where c.ComplainNo == request.ComplainNo
                    //                    select acn).ToList());

                    // = ((List<ReplyTbl>?)(from c in context.ComplainTables
                    //                                       join re in context.ReplyTbls
                    //                                       on c.Id equals re.ComplaintIdFk
                    //                                       where c.ComplainNo == request.ComplainNo
                    //                                       select re).ToList());
                    //response.Docs = 646962796170726F62686174726F79

                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public AdditionalDataTableResponse GetAdditionalData()
        {
            AdditionalDataTableResponse response = new AdditionalDataTableResponse();
            try
            {
                response.Success = true;
                response.AdditionalDataTbls = (from ad in context.AdditionalDataTbls
                                               select ad).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModelClass> AddAdditionalData(RequestModelClass model)
        {
            ResponseModelClass response = new ResponseModelClass();
            AdditionalDataTbl tbl = new AdditionalDataTbl();
            try
            {
                tbl.Data = model.RequestData;
                tbl.Name = model.RequestName;
                tbl.Description = model.RequestType;

                await context.AdditionalDataTbls.AddAsync(tbl);

                await context.SaveChangesAsync();



                response.Success = true;
                response.Message = tbl.Data;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseModelClass GetDoc(long docid)
        {
            ResponseModelClass response = new ResponseModelClass();
            try
            {
                response.Success = true;
                response.DefaultData = ((from ad in context.DocsTbls
                                         where ad.Id == docid
                                         select ad));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public ResponseModelClass GetActionData(long acid)
        {
            ResponseModelClass response = new ResponseModelClass();
            try
            {
                response.Success = true;
                response.DefaultData = ((ActionTbl?)(from ad in context.ActionTbls
                                                     where ad.Id == acid
                                                     select ad));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseModelClass GetReplyData(long reid)
        {
            ResponseModelClass response = new ResponseModelClass();
            try
            {
                response.Success = true;
                response.DefaultData = ((ReplyTbl?)(from ad in context.ReplyTbls
                                                    where ad.Id == reid
                                                    select ad)
                                               );
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public ResponseModelClass GetContactsData(long id)
        {
            ResponseModelClass response = new ResponseModelClass();
            try
            {
                response.Success = true;
                response.DefaultData = ((ContactsTbl?)(from ad in context.ContactsTbls
                                                       where ad.Id == id
                                                       select ad)
                                               );
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModelClass> GetAllContactsData()
        {
            ResponseModelClass response = new ResponseModelClass();
            try
            {
                response.Success = true;
                response.DefaultData = await ((from ad in context.ContactsTbls
                                               select ad).ToListAsync()
                                               );
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        #region reg
        public async Task<RegistrationResponse> RegisterUser(RegistrationRequest model)
        {
            RegistrationResponse _defaultResponse = new RegistrationResponse();
            try
            {


                if (!AppServices.IsEmail(model.LoginName.Trim()))
                {
                    _defaultResponse.Message = "invalid Email Format!";
                    _defaultResponse.Success = false;
                    return _defaultResponse;
                }
                if (string.IsNullOrEmpty(model.Password))
                {
                    _defaultResponse.Message = "Password Not Provided!";
                    _defaultResponse.Success = false;
                    return _defaultResponse;
                }

                if (!AppServices.IsMin8Char(model.Password))
                {
                    _defaultResponse.Message = "Password Length Should Be 8 Char minimum!";
                    _defaultResponse.Success = false;
                    return _defaultResponse;
                }

                if (String.IsNullOrEmpty(model.Name))
                {
                    _defaultResponse.Message = "Enter Proper Name!";
                    _defaultResponse.Success = false;
                    return _defaultResponse;
                }

                if (model.Usertype == 0)
                {
                    model.Usertype = 1;
                }



                var _u = (from _c in context.UserTables
                          where _c.LoginName.Equals(model.LoginName.Trim())
                          select _c).FirstOrDefault();



                if (_u == null)
                {

                    EncryptionClass _ed = new EncryptionClass();

                    var hashPassword = _ed.HashPassword(model.Password.Trim());

                    UserTable tblUser = new UserTable();
                    tblUser.LoginName = model.LoginName.Trim();
                    tblUser.PasswordHash = hashPassword;
                    tblUser.UserTypeFk = model.Usertype;
                    tblUser.Name = model.Name;


                    await context.UserTables.AddAsync(tblUser);

                    await context.SaveChangesAsync();


                    _defaultResponse.Success = true;
                    return _defaultResponse;
                }

                else
                {
                    _defaultResponse.Message = "User Already Exists";
                    _defaultResponse.Success = false;
                    return _defaultResponse;

                }

            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }

        }

        public async Task<ResponseModelClass> RegisterComplain(ComplainRequest model)
        {
            ResponseModelClass _defaultResponse = new ResponseModelClass();
            try
            {

                ComplainTable _compl = new ComplainTable();
                _compl.GdNo = model.GdNo;
                _compl.ComplainNo = model.ComplainNo;
                _compl.IsGd = model.IsGd;
                _compl.ComplainantName = model.ComplainantName;
                _compl.VictimName = model.VictimName;
                _compl.ComplainantAddress = model.ComplainantAddress;
                _compl.MobileNo = model.MobileNo;

                _compl.EmailId = model.EmailId;
                _compl.ComplainNature = model.ComplainNature;
                _compl.GistOfTheComplain = model.GistOfTheComplain;
                _compl.DateTimeOfIncident = model.DateTimeOfIncident;
                _compl.AccusedDetails = model.AccusedDetails;
                _compl.EvidenceDocPath = model.EvidenceDocPath;
                _compl.EvidenceDocFk = model.EvidenceDocFk;
                _compl.ComplainTime = DateTime.Now;



                await context.ComplainTables.AddAsync(_compl);
                await context.SaveChangesAsync();

                _defaultResponse.Success = true;
                return _defaultResponse;


            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }

        }

        public async Task<ResponseModelClass> RegisterContact(ContactsUploadRequest model)
        {
            ResponseModelClass _defaultResponse = new ResponseModelClass();
            try
            {

                ContactsTbl _compl = new ContactsTbl();
                _compl.District = model.District;
                _compl.Extra = model.Extra;
                _compl.Address = model.Address;
                _compl.Psname = model.Psname;
                _compl.Email = model.Email;
                _compl.Name = model.Name;
                _compl.ContactNumber = model.ContactNumber;
                _compl.Type= model.Type;
                _compl.OfficerName = model.OfficerName;




                await context.ContactsTbls.AddAsync(_compl);
                await context.SaveChangesAsync();

                _defaultResponse.Success = true;
                return _defaultResponse;


            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }

        }

        public async Task<ResponseModelClass> UpdateComplain(ComplainRequest model)
        {
            ResponseModelClass _defaultResponse = new ResponseModelClass();
            try
            {
                //var _complq = context.ComplainTables.AsQueryable(); ;
                ComplainTable _compl;
                if (model.IsGd == true)
                {
                    if (string.IsNullOrEmpty(model.GdNo))
                    {
                        _defaultResponse.Success = false;
                        _defaultResponse.Message = "GD no is null!";
                        return _defaultResponse;
                    }
                    _compl = (from _c in context.ComplainTables
                              where _c.GdNo == model.GdNo.Trim()
                              select _c).FirstOrDefault();
                }
                else
                {
                    if (string.IsNullOrEmpty(model.ComplainNo))
                    {
                        _defaultResponse.Success = false;
                        _defaultResponse.Message = "ComplainNo no is null!";
                        return _defaultResponse;
                    }
                    _compl = (from _c in context.ComplainTables
                              where _c.ComplainNo == model.ComplainNo.Trim()
                              select _c).FirstOrDefault();
                }



                if (_compl == null)
                {
                    _defaultResponse.Success = false;
                    _defaultResponse.Message = "No Record Found!";
                    return _defaultResponse;
                }

                _compl.GdNo = model.GdNo;
                _compl.ComplainNo = model.ComplainNo;
                _compl.IsGd = model.IsGd;
                _compl.ComplainantName = model.ComplainantName;
                _compl.VictimName = model.VictimName;
                _compl.ComplainantAddress = model.ComplainantAddress;
                _compl.MobileNo = model.MobileNo;

                _compl.EmailId = model.EmailId;
                _compl.ComplainNature = model.ComplainNature;
                _compl.GistOfTheComplain = model.GistOfTheComplain;
                _compl.DateTimeOfIncident = model.DateTimeOfIncident;
                _compl.AccusedDetails = model.AccusedDetails;
                _compl.EvidenceDocPath = model.EvidenceDocPath;
                _compl.EvidenceDocFk = model.EvidenceDocFk;
                _compl.ComplainUpdateTimes = string.IsNullOrEmpty(_compl.ComplainUpdateTimes) ? _compl.ComplainTime.ToString()
                    : (_compl.ComplainUpdateTimes + " :UPDATE: " + _compl.ComplainTime.ToString()); ;
                _compl.ComplainTime = DateTime.Now;

                context.ComplainTables.Update(_compl);
                await context.SaveChangesAsync();

                _defaultResponse.Success = true;
                return _defaultResponse;


            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }

        }


        public async Task<ResponseModelClass> RegisterAction(ActionRequest model)
        {
            ResponseModelClass _defaultResponse = new ResponseModelClass();
            try
            {

                ActionTbl _compl = new ActionTbl();
                _compl.ActionTakenBy = model.ActionTakenBy;
                _compl.WhichActionTaken = model.WhichActionTaken;
                _compl.TimeOfAction = model.TimeOfAction;
                _compl.DrNo = model.DrNo;
                _compl.IpcCrpcSection = model.IpcCrpcSection;
                _compl.EvidenceDocFk = model.EvidenceDocFk;
                _compl.AutharityName = model.AutharityName;

                _compl.ComplaintIdFk = model.ComplaintIdFk;
                // _compl.EvidenceDocPathAc = model.EvidenceDocPathAc;

                await context.ActionTbls.AddAsync(_compl);
                await context.SaveChangesAsync();

                _defaultResponse.Success = true;
                return _defaultResponse;


            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }

        }

        public async Task<ResponseModelClass> RegisterReply(ReplyRequest model)
        {
            ResponseModelClass _defaultResponse = new ResponseModelClass();
            try
            {

                ReplyTbl _compl = new ReplyTbl();
                _compl.ReplyDate = model.ReplyDate;
                _compl.CaseReferenceNo = model.CaseReferenceNo;
                _compl.AuthorityName = model.AuthorityName;
                _compl.AuthorityAddress = model.AuthorityAddress;
                _compl.ReplyGist = model.ReplyGist;
                _compl.DrNo = model.DrNo;
                _compl.EvidenceDocIdFk = model.EvidenceDocIdFk;

                _compl.ComplaintIdFk = model.ComplaintIdFk;
                _compl.SuspectStatus = model.SuspectStatus;

                _compl.CourtOrder = model.CourtOrder;
                _compl.Status = model.Status;
                _compl.CourtNameAddress = model.CourtNameAddress;
                _compl.OrderNo = model.OrderNo;
                _compl.OrderDateTime = model.OrderDateTime;
                _compl.OrderGistCourt = model.OrderGistCourt;
                _compl.OrderCopyDocFk = model.OrderCopyDocFk;

                await context.ReplyTbls.AddAsync(_compl);
                await context.SaveChangesAsync();

                _defaultResponse.Success = true;
                return _defaultResponse;


            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }

        }

        public async Task<ResponseModelClass> RegisterDocs(DocUploadRequest request)
        {
            ResponseModelClass _defaultResponse = new ResponseModelClass();
            try
            {

                DocsTbl _doc = new DocsTbl();
                _doc.DocPath = request.DocPath;
                _doc.DocName = request.Docname;
                _doc.DocUploadTime = DateTime.Now;

                await context.DocsTbls.AddAsync(_doc);
                await context.SaveChangesAsync();

                _defaultResponse.Success = true;
                _defaultResponse.DefaultData = _doc;
                return _defaultResponse;


            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }
        }

        public async Task<ResponseModelClass> LoginUser(LoginRequest model)
        {
            ResponseModelClass _defaultResponse = new ResponseModelClass();
            try
            {


                if (!AppServices.IsEmail(model.LoginName.Trim()))
                {
                    _defaultResponse.Message = "invalid Email Format!";
                    _defaultResponse.Success = false;
                    return _defaultResponse;
                }

                var _u = (from _c in context.UserTables.AsNoTracking()
                          where _c.LoginName.Equals(model.LoginName)
                          select _c).FirstOrDefault();



                if (_u != null)
                {
                    if (string.IsNullOrEmpty(model.LoginPassword))
                    {
                        _defaultResponse.Message = "Password Not Provided!";
                        _defaultResponse.Success = false;
                        return _defaultResponse;
                    }
                    EncryptionClass ed = new EncryptionClass();

                    bool isPassmatched = ed.VerifyHashedPassword(_u.PasswordHash, model.LoginPassword);

                    if (!isPassmatched)
                    {
                        _defaultResponse.Message = "Password Missmatch!";
                        _defaultResponse.Success = false;
                        return _defaultResponse;


                    }


                    SessionManager.LoggedInUserEmail = _u.LoginName;
                    SessionManager.LoggedInUserType = (long)_u.UserTypeFk;

                    await AddAdditionalData(new RequestModelClass
                    {
                        RequestData = DateTime.Now.ToString(),
                        RequestName = model.LoginName,
                        RequestType = "login_log"
                    });

                    //HttpContext.Session.SetInt32("", 773);

                    _defaultResponse.Success = true;

                    _defaultResponse.Message = _u.LoginName;
                    _defaultResponse.DefaultData = model;
                    return _defaultResponse;
                }

                else
                {
                    _defaultResponse.Message = "No User Found!";
                    _defaultResponse.Success = false;
                    return _defaultResponse;

                }

            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }

        }



        public ResponseModelClass QuickToken()
        {
            ResponseModelClass _defaultResponse = new ResponseModelClass();
            try
            {

                var _u = (from _c in context.UserTables.AsNoTracking()
                          where _c.UserTypeFk == 2
                          select _c).FirstOrDefault();



                if (_u != null)
                {
                    _defaultResponse.Message = "User Found!";
                    _defaultResponse.Success = true;
                    _defaultResponse.DefaultData = _u;
                    return _defaultResponse;
                }

                else
                {
                    _defaultResponse.Message = "No User Found!";
                    _defaultResponse.Success = false;
                    return _defaultResponse;

                }

            }
            catch (Exception _e)
            {
                _defaultResponse.Message = "failed (e) : " + _e.Message;
                _defaultResponse.Success = false;
                return _defaultResponse;


            }

        }

        #endregion


    }
}
