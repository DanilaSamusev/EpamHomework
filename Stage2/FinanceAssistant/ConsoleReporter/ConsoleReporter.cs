using System;
using Models;
using ReporterContracts;
using ConverterContracts;
using System.Collections.Generic;

namespace Reporters
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
