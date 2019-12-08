using System.Collections.Generic;
using FinancialAnalyzer;

namespace ApplicationStarter
{
    public class FinancialNoteMapper
    {
        public string MapFinancialNotesToTable(IEnumerable<FinanceNote> notes)
        {
            var table = "";
            
            foreach (var note in notes)
            {
                table += $"{note.FinanceAmount} {note.CreationDate:dd.MM.yyyy}\n";
            }

            return table;
        }
    }
}