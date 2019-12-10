using System.Collections.Generic;
using FinancialAnalyzer;

namespace FinancialService
{
    public class FinancialService : IFinancialService
    {
        private readonly FinancialFlowAnalyzer _financialFlowAnalyzer;

        public FinancialService(FinancialFlowAnalyzer financialFlowAnalyzer)
        {
            _financialFlowAnalyzer = financialFlowAnalyzer;
        }

        public IEnumerable<FinancialNoteDto> GetAllExpenses()
        {
            var expenses = _financialFlowAnalyzer.Expenses;
            IList<FinancialNoteDto> expensesDto = new List<FinancialNoteDto>();

            foreach (var expense in expenses)
            {
                expensesDto.Add(new FinancialNoteDto
                    {Id = expense.Id, CreationDate = expense.CreationDate, FinanceAmount = expense.FinanceAmount});
            }

            return expensesDto;
        }

        public IEnumerable<FinancialNoteDto> GetAllIncomes()
        {
            var expenses = _financialFlowAnalyzer.Incomes;
            IList<FinancialNoteDto> incomesDto = new List<FinancialNoteDto>();

            foreach (var expense in expenses)
            {
                incomesDto.Add(new FinancialNoteDto
                    {Id = expense.Id, CreationDate = expense.CreationDate, FinanceAmount = expense.FinanceAmount});
            }

            return incomesDto;
        }

        public void AddExpense(decimal financeAmount)
        {
            _financialFlowAnalyzer.AddExpense(financeAmount);
        }

        public void AddIncome(decimal financeAmount)
        {
            _financialFlowAnalyzer.AddIncome(financeAmount);
        }
    }
}