using System;
using System.Collections.Generic;

namespace PersonalFinancialHelper
{
    public class CashFlowAnalyzer
    {
        public List<CashNote> IncomeNotes { get; }
        public List<CashNote> ExpensesNotes { get; }

        public CashFlowAnalyzer()
        {
            IncomeNotes = new List<CashNote>();
            ExpensesNotes = new List<CashNote>();
        }

        public void AddNoteAboutIncome(decimal cashAmount)
        {
            if (cashAmount <= 0)
            {
                throw new ArgumentException(Constants.CashAmountInputError);
            }

            var cashNote = new CashNote(IncomeNotes.Count + 1, cashAmount);
            IncomeNotes.Add(cashNote);
        }

        public void AddNoteAboutExpense(decimal cashAmount)
        {
            if (cashAmount <= 0)
            {
                throw new ArgumentException(Constants.CashAmountInputError);
            }

            var cashNote = new CashNote(ExpensesNotes.Count + 1, cashAmount);
            ExpensesNotes.Add(cashNote);
        }
    }
}