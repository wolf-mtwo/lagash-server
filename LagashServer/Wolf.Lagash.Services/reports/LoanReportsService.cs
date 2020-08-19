using System;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.reports;
using Wolf.Lagash.Interfaces.reports;

namespace Wolf.Lagash.Services.reports
{
    public class LoanReportsService : EFAdapterBase<LoanReports>, ILoanReportsService
    {
        public LoanReportsService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<LoanReports>().Count(e => e._id == id) > 0;
        }
    }
}
