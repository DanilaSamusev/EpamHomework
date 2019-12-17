using System;
using Models;
using ReporterContracts;    
using System.Collections.Generic;

namespace ConsoleReporter
{
    class Reporter : IReporter
    {
        public void SaveReport(IEnumerable<FinanceNote> notes)
        {
            foreach (var note in notes)
            {
                Console.WriteLine($"{note.Id}. {note.FinanceAmount}$ date: {note.CreationDate}");
            }
        }
    }
}
