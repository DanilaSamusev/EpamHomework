using System.Collections.Generic;

namespace FinancialService
{
    public interface IFinancialService
    {
        IEnumerable<FinancialNoteDto> GetAllExpenses();
        IEnumerable<FinancialNoteDto> GetAllIncomes();
        decimal GetTotalFinancialFlow();
        void AddExpense(decimal financeAmount);
        void AddIncome(decimal financeAmount);
    }
}