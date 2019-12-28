using System.Collections.Generic;
using Contracts.ConverterContracts;
using Contracts.Models;

namespace Business.Converters
{
    public class FinanceNoteToStringConverter : IFinanceNoteConverter
    {
        public string ConvertFinanceNotesToTable(IEnumerable<FinanceNote> financeNotes)
        {
            var stringTable = string.Empty;

            if (financeNotes == null)
            {
                return "You haven't any notes";
            }

            foreach (var financeNote in financeNotes)
            {
                stringTable +=
                    $"{financeNote.FinanceAmount}$ on {financeNote.CreationDate:dd.MM.yyyy}\n";
            }

            return stringTable;
        }
    }
}