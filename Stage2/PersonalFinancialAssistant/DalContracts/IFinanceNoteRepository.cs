using System.Collections.Generic;
using Models;

namespace DalContracts
{
    public interface IFinanceNoteRepository
    {
        void AddIncomeNote(FinanceNote note);
        void AddExpenseNote(FinanceNote note);
        IEnumerable<FinanceNote> GetAllNotes();
    }
}
