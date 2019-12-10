using System.Collections.Generic;

namespace FinancialService
{
    public interface IFinancialService
    {
        IEnumerable<FinancialNoteDto> GetAllExpenses();
        IEnumerable<FinancialNoteDto> GetAllIncomes();
        void AddExpense(decimal financeAmount);
        void AddIncome(decimal financeAmount);
    }
}