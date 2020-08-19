using System;
using Wolf.Core.Interfaces;
using Wolf.Lagash.Entities.reports;

namespace Wolf.Lagash.Interfaces.reports
{
    public interface ILoanReportsService : IAdapterBase<LoanReports>
    {
        bool exists(String id);
    }
}
