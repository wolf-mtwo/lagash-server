using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Services.reports;
using Wolf.Lagash.Interfaces.reports;
using Wolf.Lagash.Entities.reports;

namespace LagashServer.Controllers.v5
{
    [RoutePrefix("v5/search")]
    public class V5SearchController : ApiController
    {
        private ISearchReportsService service = new SearchReportsService(new LagashContext());

        [Route("")]
        public IHttpActionResult Post(SearchReports item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                service.Create(item);
                service.Commit();
            }
            catch (Exception e)
            {
                return new LagashActionResult(e.Message);
            }
            return Ok(item);
        }

        [Route("total")]
        public IEnumerable<SearchReports> GetTotals(DateTime start_date, DateTime end_date, string search)
        {
            if (search == null) search = "";
            return service.get_desc((o) => {
                return o.created > start_date && o.created < end_date && o.search.Contains(search);
            }, o => o.created);
        }
    }
}