using System.Collections.Generic;
using Models;

namespace ReporterContracts
{
    public interface IReporter
    {
        void SaveReport(IEnumerable<FinanceNote> notes);      
    }
}
