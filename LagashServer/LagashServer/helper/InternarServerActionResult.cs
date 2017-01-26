using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace LagashServer.helper
{
    public class LagashActionResult : IHttpActionResult
    {
        public string message;

        public LagashActionResult(string message)
        {
            this.message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            response.Content = new ObjectContent<LagashActionResult>(this, new JsonMediaTypeFormatter());
            return Task.FromResult(response);
        }
    }
}