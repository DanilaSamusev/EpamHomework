using System.Collections.Generic;
using FinancialService;

namespace Client
{
    public class FinancialNoteConverter
    {
        public string ConvertFinancialNoteToStringTable(IEnumerable<FinancialNoteDto> notes)
        {
            var table = "";
            
            foreach (var note in notes)
            {
                table += $"finance: {note.FinanceAmount} | date: {note.CreationDate:dd.MM.yyyy}\n";
            }

            return table;
        }
    }
}