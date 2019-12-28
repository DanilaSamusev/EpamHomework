using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.ConverterContracts
{
    public interface IFinanceNoteConverter
    {
        string ConvertFinanceNotesToTable(IEnumerable<FinanceNote> financeNotes);
    }
}