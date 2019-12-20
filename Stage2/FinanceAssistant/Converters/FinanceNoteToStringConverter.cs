using ConverterContracts;
using Models;
using System.Collections.Generic;

namespace Converters
{
    public class FinanceNoteToStringConverter : IFinanceNoteConverter
    {
        public string ConvertFinanceNotesToTable(IEnumerable<FinanceNote> financeNotes)
        {
            var stringTable = string.Empty;

            if (financeNotes == null)
            {
                return "You have't any notes";
            }

            foreach(var financeNote in financeNotes)
            {
                stringTable += $"{financeNote.Id}. {financeNote.FinanceAmount}$ on {financeNote.CreationDate}";
            }

            return stringTable;
        }
    }
}
