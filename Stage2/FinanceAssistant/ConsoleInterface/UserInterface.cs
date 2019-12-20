﻿using System;
using ServiceContracts;
using ReporterContracts;
using Enums;

namespace ConsoleUserInterface
{
    public class UserInterface
    {
        private readonly IFinanceService _financeService;
        private readonly IReporter _reporter;       
        private const string AddingIsSuccessful = "Data has been added.";
        private const string MenuMessage = "To add an income press 1\n" +
                                           "To add an expense press 2\n" +
                                           "To see all your incomes press 3\n" +
                                           "To see all your expenses press 4\n" +
                                           "To see your total financial flow press 5\n" +
                                           "To finish session press 6\n";

        public UserInterface(IFinanceService financeService, IReporter reporter)
        {
            _financeService = financeService;         
            _reporter = reporter;           
        }

        public void Run()
        {
            var sessionIsOver = false;
            Console.WriteLine(MenuMessage);

            while (!sessionIsOver)
            {
                Console.Write("Enter required key: ");
                Console.WriteLine();
                var actionKey = Console.ReadKey();
                PerformAction(actionKey);
            }
        }

        private void PerformAction(ConsoleKeyInfo actionKey)
        {
            Console.WriteLine(actionKey.KeyChar);

            switch ((int)actionKey.KeyChar)
            {
                case (int)Operation.AddIncome:
                    {
                        var financeAmount = GetFinanceAmount();
                        _financeService.AddIncomeNote(financeAmount);
                        Console.WriteLine(AddingIsSuccessful);
                        break;
                    }
                case (int)Operation.AddExpense:
                    {
                        var financeAmount = GetFinanceAmount();
                        _financeService.AddExpenseNote(financeAmount);
                        Console.WriteLine(AddingIsSuccessful);
                        break;
                    }
                case (int)Operation.ShowIncomes:
                    {
                        Console.WriteLine("Your incomes:");
                        var financeNotes = _financeService.GetAllIncomes();                       
                        _reporter.SaveReport(financeNotes);
                        break;
                    }
                case (int)Operation.ShowExpenses:
                    {
                        Console.WriteLine("Your expenses:");
                        var financeNotes = _financeService.GetAllExpences();
                        _reporter.SaveReport(financeNotes);
                        break;
                    }
                case (int)Operation.ShowTotalFinancialFlow:
                    {
                        Console.Write("Your financial flow: ");
                        var totalFinancialFlow = _financeService.GetTotalFinanceFlow();
                        Console.WriteLine($"{totalFinancialFlow}$");
                        break;
                    }
            }
        }

        private decimal GetFinanceAmount()
        {
            Console.Write("Enter finance amount: ");
            Console.WriteLine();
            var numberIsParsed = decimal.TryParse(Console.ReadLine(), out decimal parsedFinanceAnount);

            if (numberIsParsed)
            {
                return parsedFinanceAnount;
            }

            throw new ArgumentException("Error! Enter a positive number");
        }
    }
}
