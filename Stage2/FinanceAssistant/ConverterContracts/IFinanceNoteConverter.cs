using Models;
using System.Collections.Generic;

namespace ConverterContracts
{
    public interface IFinanceNoteConverter
    {
        string ConvertFinanceNotesToTable(IEnumerable<FinanceNote> financeNotes);
    }
}
