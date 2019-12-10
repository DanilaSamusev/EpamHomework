using System;
using System.Collections.Generic;

namespace FinancialAnalyzer
{
    public class FinancialFlowAnalyzer
    {
        private const string FinancialNoteAddingError = "Error! Money amount has to be a positive number.";
        public List<FinanceNote> Incomes { get; }
        public List<FinanceNote> Expenses { get; }

        public FinancialFlowAnalyzer()
        {
            Incomes = new List<FinanceNote>();
            Expenses = new List<FinanceNote>();
        }

        public void AddIncome(decimal cashAmount)
        {
            if (cashAmount <= 0)
            {
                throw new ArgumentException(FinancialNoteAddingError);
            }

            var cashNote = new FinanceNote(Incomes.Count + 1, cashAmount);
            Incomes.Add(cashNote);
        }

        public void AddExpense(decimal cashAmount)
        {
            if (cashAmount <= 0)
            {
                throw new ArgumentException(FinancialNoteAddingError);
            }

            var cashNote = new FinanceNote(Expenses.Count + 1, cashAmount);
            Expenses.Add(cashNote);
        }
    }
}