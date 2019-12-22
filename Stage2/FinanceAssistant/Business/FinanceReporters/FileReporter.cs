using System.Collections.Generic;
using System.IO;
using Contracts.ConverterContracts;
using Contracts.Models;
using Contracts.ReporterContracts;

namespace Business.FinanceReporters
{
    public class FileReporter : IReporter
    {
        private readonly string _filePath;
        private readonly IFinanceNoteConverter _financeNoteConverter;
        
        public FileReporter(string filePath, IFinanceNoteConverter financeNoteConverter)
        {
            _filePath = filePath;
            _financeNoteConverter = financeNoteConverter;
        }
        
        public void SaveReport(IEnumerable<FinanceNote> notes, string reportTitle)
        {
            using (var writer = new StreamWriter(_filePath, false, System.Text.Encoding.Default))
            {
                var table = _financeNoteConverter.ConvertFinanceNotesToTable(notes);
                writer.WriteLine($"{reportTitle}\n{table}");
            }
        }
    }
}