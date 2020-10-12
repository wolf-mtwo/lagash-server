using System;
using System.Collections.Generic;
using System.Web.Http;
using LagashServer.helper;
using Wolf.Lagash.Services.reports;
using Wolf.Lagash.Interfaces.reports;
using Wolf.Lagash.Entities.reports;

namespace LagashServer.Controllers.v5
{
    [RoutePrefix("v5/loans")]
    public class V5LoansController : ApiController
    {
        private ILoanReportsService service = new LoanReportsService(new LagashContext());

        [Route("daily")]
        public IEnumerable<LoanReports> GetTotals(DateTime start_date, DateTime end_date, string search)
        {
            return service.get_desc((o) => {
                return o.created > start_date && o.created < end_date;
            }, o => o.created);
        }

        [Route("faculties")]
        public IEnumerable<LoanReports> GetFacultyTotals(DateTime start_date, DateTime end_date, string faculty_id)
        {
            return service.get_desc((o) => {
                return o.created > start_date && o.created < end_date && o.faculty_id.Equals(faculty_id);
            }, o => o.created);
        }

        [Route("person")]
        public IEnumerable<LoanReports> GetPersonTotals(DateTime start_date, DateTime end_date, string reader_id)
        {
            return service.get_desc((o) => {
                return o.created > start_date && o.created < end_date && o.reader_id.Equals(reader_id);
            }, o => o.created);
        }

        [Route("readers")]
        public IEnumerable<LoanReports> GetReaderTotals(int page, int limit, string reader_id)
        {
            return service.Where(page, limit, (o) => {
                return o.reader_id.Equals(reader_id);
            }, o => o.created);
        }
    }
}