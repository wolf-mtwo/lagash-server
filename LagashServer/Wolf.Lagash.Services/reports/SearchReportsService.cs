using System;
using System.Data.Entity;
using System.Linq;
using Wolf.Core.EntityFramework;
using Wolf.Lagash.Entities.reports;
using Wolf.Lagash.Interfaces.reports;

namespace Wolf.Lagash.Services.reports
{
    public class SearchReportsService : EFAdapterBase<SearchReports>, ISearchReportsService
    {
        public SearchReportsService(DbContext Context) : base(Context)
        {
        }

        public bool exists(String id)
        {
            return context.Set<SearchReports>().Count(e => e._id == id) > 0;
        }
    }
}
