﻿using System;
using Business.FinanceAnalyzer;
using Contracts.Enums;
using Contracts.ReporterContracts;
using Contracts.ServiceContracts;

namespace ConsoleUserInterface
{
    public class UserInterface
    {
        private readonly IFinanceNoteService _financeNoteService;
        private readonly IReporter _reporter;
        private readonly FinanceAnalyzer _financeFlowAnalyzer;
        private const string AddingIsSuccessful = "Data has been added.";
        private const string MenuMessage = "To add an income press 1\n" +
                                           "To add an expense press 2\n" +
                                           "To see all your incomes press 3\n" +
                                           "To see all your expenses press 4\n" +
                                           "To see your total financial flow press 5\n" +
                                           "To finish session press 6\n";

        public UserInterface(IFinanceNoteService financeNoteService, IReporter reporter,
            FinanceAnalyzer financeFlowAnalyzer)
        {
            _financeNoteService = financeNoteService;
            _reporter = reporter;
            _financeFlowAnalyzer = financeFlowAnalyzer;
        }

        public void Run()
        {
            var sessionIsOver = false;
            Console.WriteLine(MenuMessage);

            while (!sessionIsOver)
            {
                Console.Write("Enter required key: ");
                var actionKey = Console.ReadKey();
                Console.WriteLine();
                PerformAction(actionKey);

                if (char.GetNumericValue(actionKey.KeyChar) == (double)Operation.Exit)
                {
                    sessionIsOver = true;
                }
            }
        }

        private void PerformAction(ConsoleKeyInfo actionKey)
        {
            switch (char.GetNumericValue(actionKey.KeyChar))
            {
                case (double) Operation.AddIncome:
                {
                    var financeAmount = GetFinanceAmount();
                    _financeNoteService.AddIncomeNote(financeAmount);
                    Console.WriteLine(AddingIsSuccessful);
                    break;
                }
                case (double) Operation.AddExpense:
                {
                    var financeAmount = GetFinanceAmount();
                    _financeNoteService.AddExpenseNote(financeAmount);
                    Console.WriteLine(AddingIsSuccessful);
                    break;
                }
                case (double) Operation.ShowIncomes:
                {
                    var financeNotes = _financeNoteService.GetAllIncomes();
                    _reporter.SaveReport(financeNotes, "Your incomes: ");
                    break;
                }
                case (double) Operation.ShowExpenses:
                {
                    var financeNotes = _financeNoteService.GetAllExpenses();
                    _reporter.SaveReport(financeNotes, "Your expenses: ");
                    break;
                }
                case (double) Operation.ShowTotalFinancialFlow:
                {
                    Console.Write("Your financial flow: ");
                    var totalFinancialFlow = _financeFlowAnalyzer.GetTotalFinanceFlow();
                    Console.WriteLine($"{totalFinancialFlow}$");
                    break;
                }
            }
        }

        private decimal GetFinanceAmount()
        {
            Console.Write("Enter finance amount: ");
            Console.WriteLine();
            var numberIsParsed = decimal.TryParse(Console.ReadLine(), out decimal parsedFinanceAmount);

            if (numberIsParsed)
            {
                return parsedFinanceAmount;
            }

            throw new ArgumentException("Error! Enter a positive number");
        }
    }
}