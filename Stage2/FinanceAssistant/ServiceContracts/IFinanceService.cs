using Models;
using System.Collections.Generic;

namespace ServiceContracts
{
    public interface IFinanceService
    {
        void AddExpenseNote(decimal financeAmount);

        void AddIncomeNote(decimal financeAmount);

        public IEnumerable<FinanceNote> GetAllIncomes();

        public IEnumerable<FinanceNote> GetAllExpences();
        
        IEnumerable<FinanceNote> GetAllFinanceNotes();

    }
}
