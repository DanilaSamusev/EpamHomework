using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.ServiceContracts
{
    public interface IFinanceNoteService
    {
        void AddExpenseNote(decimal financeAmount);

        void AddIncomeNote(decimal financeAmount);

        IEnumerable<FinanceNote> GetAllIncomes();

        IEnumerable<FinanceNote> GetAllExpenses();

        IEnumerable<FinanceNote> GetAllNotes();

        IEnumerable<FinanceNote> GetAllNotes(int userId);
    }
}