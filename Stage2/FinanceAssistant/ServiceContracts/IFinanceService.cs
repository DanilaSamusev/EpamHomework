using Models;
using System.Collections.Generic;

namespace ServiceContracts
{
    public interface IFinanceService
    {
        void AddExpenseNote(decimal financeAmount);

        void AddIncomeNote(decimal financeAmount);

        IEnumerable<FinanceNote> GetAllIncomes();

        IEnumerable<FinanceNote> GetAllExpences();            

        decimal GetTotalFinanceFlow();
    }
}
