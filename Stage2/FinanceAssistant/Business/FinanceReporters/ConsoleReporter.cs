using System;
using System.Collections.Generic;
using Contracts.ConverterContracts;
using Contracts.Models;
using Contracts.ReporterContracts;

namespace Business.FinanceReporters
{
    public class ConsoleReporter : IReporter
    {
        private readonly IFinanceNoteConverter _financeNoteConverter;

        public ConsoleReporter(IFinanceNoteConverter financeNoteConverter)
        {
            _financeNoteConverter = financeNoteConverter;
        }

        public void SaveReport(IEnumerable<FinanceNote> notes)
        {
            var table = _financeNoteConverter.ConvertFinanceNotesToTable(notes);

            Console.WriteLine(table);
        }
    }
}