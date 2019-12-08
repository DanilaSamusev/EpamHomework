using System;
using PersonalFinancialHelper;

namespace UserInterface
{
    public class ConsoleInterface 
    {
        public void Run()
        {
            var cashFlowAnalyzer = new CashFlowAnalyzer();
            var cashNotesConverter = new CashNotesConverter();
            var isSessionOver = false;

            Console.WriteLine(Constants.Menu);
            
            while (!isSessionOver)
            {
                try
                {
                    Console.Write("Press required key: ");
                    var key = Console.ReadLine();
                    
                    switch (key)
                    {
                        case "1":
                        {
                            var cashAmount = AskCashAmount();
                            cashFlowAnalyzer.AddNoteAboutIncome(cashAmount);
                            Console.WriteLine("Data has been added.");
                            break;
                        }
                        case "2":
                        {
                            var cashAmount = AskCashAmount();
                            cashFlowAnalyzer.AddNoteAboutExpense(cashAmount);
                            Console.WriteLine("Data has been added.");
                            break;
                        }
                        case "3":
                        {
                            Console.WriteLine("Your incomes");
                            Console.WriteLine(cashNotesConverter.GetNotesAsTable(cashFlowAnalyzer.IncomeNotes));
                            break;
                        }
                        case "4":
                        {
                            Console.WriteLine("Your expenses");
                            Console.WriteLine(cashNotesConverter.GetNotesAsTable(cashFlowAnalyzer.ExpensesNotes));
                            break;
                        }
                        case "5":
                        {
                            isSessionOver = true;
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private decimal AskCashAmount()
        {
            Console.Write("Inter cash amount: ");
            var cashAmount = Console.ReadLine();
            var isCashAmountParsed = decimal.TryParse(cashAmount, out var parsedCashAmount);
            
            if (isCashAmountParsed)
            {
                return parsedCashAmount;
            }
            
            throw new ArgumentException(Constants.CashAmountInputError);
        }
    }
}