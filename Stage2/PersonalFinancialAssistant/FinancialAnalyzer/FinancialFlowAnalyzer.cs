using System;
using System.Collections.Generic;

namespace FinancialAnalyzer
{
    public class FinancialFlowAnalyzer
    {
        private const string FinancialNoteAddingError = "Error! Money amount has to be a positive number.";
        public List<FinancialNote> Incomes { get; }
        public List<FinancialNote> Expenses { get; }

        public FinancialFlowAnalyzer()
        {
            Incomes = new List<FinancialNote>();
            Expenses = new List<FinancialNote>();
        }

        public void AddIncome(decimal cashAmount)
        {
            if (cashAmount <= 0)
            {
                throw new ArgumentException(FinancialNoteAddingError);
            }

            var cashNote = new FinancialNote(Incomes.Count + 1, cashAmount);
            Incomes.Add(cashNote);
        }

        public void AddExpense(decimal cashAmount)
        {
            if (cashAmount <= 0)
            {
                throw new ArgumentException(FinancialNoteAddingError);
            }

            var cashNote = new FinancialNote(Expenses.Count + 1, cashAmount);
            Expenses.Add(cashNote);
        }

        public decimal CountTotalFinancialFlow()
        {
            decimal totalFinancialFlow = 0;

            foreach (var income in Incomes)
            {
                totalFinancialFlow += income.FinanceAmount;
            }

            foreach (var expense in Expenses)
            {
                totalFinancialFlow -= expense.FinanceAmount;
            }

            return totalFinancialFlow;
        }
    }
}