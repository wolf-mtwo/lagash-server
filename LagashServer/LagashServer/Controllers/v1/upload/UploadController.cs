using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Threading.Tasks;

namespace LagashServer.Controllers.v1.books
{
    [RoutePrefix("v1/upload")]
    public class UploadController : ApiController
    {
        [Route("")]
        public async Task<IHttpActionResult> Post()
        {
            String fileName = null;
            var httpRequest = HttpContext.Current.Request;

            foreach (string file in httpRequest.Files)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                var postedFile = httpRequest.Files[file];
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                    fileName = Guid.NewGuid().ToString() + ext.ToLower();
                    //var filePath = HttpContext.Current.Server.MapPath("~/files/" + fileName + "/" + ext.ToLower());
                    string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "files/" + fileName);
                    postedFile.SaveAs(filePath);
                }
            }
            return Ok(new helpers.File(fileName));
        }
    }
}