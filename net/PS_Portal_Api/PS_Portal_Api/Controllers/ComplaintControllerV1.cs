using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS_Portal_Api.Models;
using PS_Portal_Api.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PS_Portal_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintControllerV1 : ControllerBase
    {
        private psportal_dbContext _context;
        private ComplainDataClass _dataClass;
        public ComplaintControllerV1(psportal_dbContext context)
        {
            _context = context;
            _dataClass = new ComplainDataClass(context);
         }
        // GET: api/<ComplaintControllerV1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        //[Authorize]
        [Route("GetAdditionalData")]
        public AdditionalDataTableResponse GetAdditionalData()
        {
            return _dataClass.GetAdditionalData();
        }

        // GET api/<ComplaintControllerV1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComplaintControllerV1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ComplaintControllerV1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComplaintControllerV1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFileCollection files)
        {
            foreach (var fileName in files)
            {
                var filesPath = Directory.GetCurrentDirectory() + "/Uploadfiles";
                if (!System.IO.Directory.Exists(filesPath))//create path 
                {
                    Directory.CreateDirectory(filesPath);
                }
                var path = Path.Combine(filesPath, Path.GetFileName(fileName.FileName));//the path to upload
                await fileName.CopyToAsync(new FileStream(path, FileMode.Create));

            }
            return Ok();
        }

        [HttpPost]
        [Route("RegisterDoc")]
        public async Task<ResponseModelClass> RegisterDoc(DocUploadRequest request)
        {

            return _dataClass.RegisterDocs(request).Result;
        }

        [HttpGet]
        [Route("GetSingleDoc{docid}")]
        public async Task<ResponseModelClass> GetSingleDoc(long docid)
        {

            return _dataClass.GetDoc(docid);
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ResponseModelClass> RegisterUser(RegistrationRequest request)
        {
            
            return  _dataClass.RegisterUser(request).Result;
        }
        [HttpPost]
        [Route("LoginUser")]
        public async Task<ResponseModelClass> LoginUser(LoginRequest request)
        {

            return await _dataClass.LoginUser(request);
        }
        [HttpPost]
        [Route("RegisterComplain")]
        public async Task<ResponseModelClass> RegisterComplain(ComplainRequest request)
        {

            return _dataClass.RegisterComplain(request).Result;
        }

        [HttpPost]
        [Route("UpdateComplain")]
        public async Task<ResponseModelClass> UpdateComplain(ComplainRequest request)
        {

            return _dataClass.UpdateComplain(request).Result;
        }
        [HttpPost]
        [Route("RegisterAction")]
        public async Task<ResponseModelClass> RegisterAction(ActionRequest request)
        {

            return _dataClass.RegisterAction(request).Result;
        }

        [HttpPost]
        [Route("RegisterReply")]
        public async Task<ResponseModelClass> RegisterReply(ReplyRequest request)
        {

            return _dataClass.RegisterReply(request).Result;
        }

        [HttpGet]
        [Route("GetAllComplains")]
        public async Task<ResponseModelClass> GetAllComplains()
        {

            return _dataClass.GetAllComplainData().Result;
        }

        [HttpPost]
        [Route("GetSingleComplainData")]
        public async Task<ResponseModelClass> GetSingleComplainData([FromBody]ComplaintViewRequest request)
        {

            return _dataClass.GetSingleComplainData(request).Result;
        }
    }
}
