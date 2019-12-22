using System.Collections.Generic;
using Contracts.Models;
using Contracts.ReporterContracts;

namespace Business.FinanceReporters
{
    public class FileReporter : IReporter
    {
        private readonly string _filePath;
        
        public FileReporter(string filePath)
        {
            _filePath = filePath;
        }
        
        public void SaveReport(IEnumerable<FinanceNote> notes)
        {
            throw new System.NotImplementedException();
        }
    }
}