using Models;
using System.Collections.Generic;

namespace ServicesContracts
{
    interface IFinanceService
    {
        void AddExpenseNote(FinanceNote note);
        void AddIncomeNote(FinanceNote note);
        IEnumerable<FinanceNote> GetAllFinanceNotes();

    }
}
