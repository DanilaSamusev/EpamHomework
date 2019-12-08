using System.Collections.Generic;
using FinancialAnalyzer;

namespace ApplicationStarter
{
    public class CashNoteMapper
    {
        public string MapCashNoteToTable(IEnumerable<CashNote> notes)
        {
            var table = "";
            
            foreach (var note in notes)
            {
                table += $"{note.CashAmount} {note.CreationDate:dd.MM.yyyy}\n";
            }

            return table;
        }
    }
}