using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.ReporterContracts
{
    public interface IReporter
    {
        void SaveReport(IEnumerable<FinanceNote> notes);      
    }
}