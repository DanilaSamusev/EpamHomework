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
                table += $"Finance amount: {note.FinanceAmount} | date: {note.CreationDate:dd.MM.yyyy}\n";
            }

            return table;
        }
    }
}