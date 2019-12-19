using Models;
using ServiceContracts;
using System.Collections.Generic;

namespace Services
{
    class FinanceService : IFinanceService
    {
        public void AddExpenseNote(decimal financeAmount)
        {
            throw new System.NotImplementedException();
        }

        public void AddIncomeNote(decimal financeAmount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FinanceNote> GetAllIncomes()
        {
            return null;
        }

        public IEnumerable<FinanceNote> GetAllExpences()
        {
            return null;
        }

        public IEnumerable<FinanceNote> GetAllFinanceNotes()
        {
            throw new System.NotImplementedException();
        }
    }
}
