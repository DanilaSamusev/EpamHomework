using System;
using System.Collections.Generic;

namespace FinancialAnalyzer
{
    public class FinancialFlowAnalyzer
    {
        private const string FinancialNoteAddingError = "Error! Money amount has to be a positive number.";
        private const decimal Taxes = 13;
        public List<FinancialNote> Incomes { get; }
        public List<FinancialNote> Expenses { get; }

        public FinancialFlowAnalyzer()
        {
            Incomes = new List<FinancialNote>();
            Expenses = new List<FinancialNote>();
        }

        public void AddIncome(decimal financeAmount)
        {
            if (financeAmount <= 0)
            {
                throw new ArgumentException(FinancialNoteAddingError);
            }

            var financeAmountWithTaxes = CountFinanceAmountWithTaxes(financeAmount);
            var financeNote = new FinancialNote(Incomes.Count + 1, financeAmountWithTaxes);
            Incomes.Add(financeNote);
        }

        public void AddExpense(decimal financeAmount)
        {
            if (financeAmount <= 0)
            {
                throw new ArgumentException(FinancialNoteAddingError);
            }

            var financeNote = new FinancialNote(Expenses.Count + 1, financeAmount);
            Expenses.Add(financeNote);
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

        private decimal CountFinanceAmountWithTaxes(decimal financeAmount)
        {
            return financeAmount / 100 * (100 - Taxes);
        }
    }
}