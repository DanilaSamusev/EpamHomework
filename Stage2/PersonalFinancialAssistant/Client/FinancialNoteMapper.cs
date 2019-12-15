using System.Collections.Generic;
using FinancialService;

namespace Client
{
    public class FinancialNoteMapper
    {
        public string MapFinancialNotesToTable(IEnumerable<FinancialNoteDto> notes)
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