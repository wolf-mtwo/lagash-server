using System;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.reports;

namespace Wolf.Lagash.Interfaces.reports
{
    public interface ISearchReportsService : IAdapterBase<SearchReports>
    {
        bool exists(String id);
    }
}
