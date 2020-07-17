using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using Wolf.Lagash.Services;
using Wolf.Lagash.Interfaces;
using LagashServer.helper;
using System.Linq;

namespace LagashServer.Controllers.v1.books
{
    [RoutePrefix("v6/search")]
    public class V6SearchController : ApiController
    {
        private ISearchService service = new SearchService(new LagashContext());
       
        [Route("page/{page}/limit/{limit}")]
        public IHttpActionResult Get(int page, int limit, string type, string listAuthor, string listEditorial, 
                string listYear, bool isAll, string search)
        {
            try
            {
                var listSearch = service.SearchItems(type, isAll, search, listAuthor, listEditorial, listYear, page, limit);

                var years = listSearch.Where(i => !String.IsNullOrEmpty( i.MaterialYear)).Select(i => i.MaterialYear).Distinct();
                var authors = listSearch.Where(i => !String.IsNullOrEmpty(i.Autor)).Select(i => i.Autor).Distinct();
                var editorials = listSearch.Where(i => !String.IsNullOrEmpty(i.Editorial)).Select(i => i.Editorial).Distinct();

                int totalRows = 0;

                if (listSearch?.Count > 0)
                {
                    totalRows = listSearch.FirstOrDefault().Total;
                }
                return Ok(new { totalRows, years, authors, editorials, data = listSearch });
            }
            catch (Exception e)
            {
                return Ok(new { error = true });
            }
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("running");
        }
    }
}