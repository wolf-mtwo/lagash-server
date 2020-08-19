using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LagashServer.Controllers.v1.upload
{
    [Authorize]
    [RoutePrefix("v1/upload")]
    public class UploadController : ApiController
    {
        [Route("")]
        public async Task<IHttpActionResult> Post()
        {
            string fileName = null;
            var httpRequest = HttpContext.Current.Request;

            foreach (string file in httpRequest.Files)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                var postedFile = httpRequest.Files[file];

                BinaryReader b = new BinaryReader(postedFile.InputStream);
                byte[] binData = b.ReadBytes(postedFile.ContentLength);
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                    fileName = Guid.NewGuid().ToString() + ext.ToLower();
                    //var filePath = HttpContext.Current.Server.MapPath("~/files/" + fileName + "/" + ext.ToLower());

                    string filePathThumbnail = Path.Combine(HttpRuntime.AppDomainAppPath, "files/thumbnail/" + fileName);
                    File.WriteAllBytes(filePathThumbnail, ResizeImage(binData, 200));

                    string filePathThumbnailHD = Path.Combine(HttpRuntime.AppDomainAppPath, "files/hd/" + fileName);
                    File.WriteAllBytes(filePathThumbnailHD, ResizeImage(binData));

                    string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "files/original/" + fileName);
                    postedFile.SaveAs(filePath);
                }
            }
            return Ok(new Controllers.helpers.File(fileName));
        }

        public byte[] ResizeImage(byte[] file, int width = 1024)
        {
            try
            {
                var stream = new MemoryStream(file);
                var img = Image.FromStream(stream);
                int newHeight;
                //resize proportional
                int originalWidth = img.Width;
                int originalHeight = img.Height;
                newHeight = width * originalHeight / originalWidth;
                var ms = new MemoryStream();
                Bitmap b = new Bitmap(width, newHeight);
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, newHeight);
                g.Dispose();
                b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.GetBuffer();
            }
            catch (Exception)
            {
                return file;
            }
        }
    }
}