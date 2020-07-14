using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using Wolf.Lagash.Services;
using Wolf.Lagash.Interfaces;
using LagashServer.helper;

namespace LagashServer.Controllers.v1.books
{
    [RoutePrefix("v6/search")]
    public class V6SearchController : ApiController
    {
        private ISearchService service = new SearchService(new LagashContext());
       
        [Route("page/{page}/limit/{limit}")]
        public IHttpActionResult Get(int page, int limit, string type, bool isAll, string search)
        {
            var listSearch = service.SearchItems(type, isAll, search, page, limit);
            return Ok(listSearch);
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("running");
        }
    }
}