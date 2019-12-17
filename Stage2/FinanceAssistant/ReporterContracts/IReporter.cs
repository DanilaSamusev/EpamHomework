using System.Collections.Generic;
using Models;

namespace ReporterContracts
{
    public interface IReporter
    {
        void MakeReport(IEnumerable<FinanceNote> notes);      
    }
}
