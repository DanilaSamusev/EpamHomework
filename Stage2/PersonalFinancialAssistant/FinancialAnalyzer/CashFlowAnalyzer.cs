using System;
using System.Collections.Generic;

namespace FinancialAnalyzer
{
    public class CashFlowAnalyzer
    {
        private const string FinancialNoteAddingError = "Error! Money amount has to be a positive number.";
        public List<CashNote> Incomes { get; }
        public List<CashNote> Expenses { get; }

        public CashFlowAnalyzer()
        {
            Incomes = new List<CashNote>();
            Expenses = new List<CashNote>();
        }

        public void AddNoteAboutIncome(decimal cashAmount)
        {
            if (cashAmount <= 0)
            {
                throw new ArgumentException(FinancialNoteAddingError);
            }

            var cashNote = new CashNote(Incomes.Count + 1, cashAmount);
            Incomes.Add(cashNote);
        }

        public void AddNoteAboutExpense(decimal cashAmount)
        {
            if (cashAmount <= 0)
            {
                throw new ArgumentException(FinancialNoteAddingError);
            }

            var cashNote = new CashNote(Expenses.Count + 1, cashAmount);
            Expenses.Add(cashNote);
        }
    }
}