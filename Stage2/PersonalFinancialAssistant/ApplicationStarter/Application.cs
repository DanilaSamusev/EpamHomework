using System;
using Client;
using Client.Interfaces;
using FinancialAnalyzer;

namespace ApplicationStarter
{
    public class Application
    {
        private const string MenuMessage = "If you want to add an income press 1\n" +
                                    "to add an expense press 2\n" +
                                    "to see all your incomes press 3\n" +
                                    "to see all your expenses press 4\n" +
                                    "to finish session press 5\n";
        private const string AddingIsSuccessful = "Data has been added.";
        private readonly IClient _client;
        private readonly CashFlowAnalyzer _cashFlowAnalyzer;
        private readonly CashNoteMapper _cashNoteMapper;

        public Application()
        {
            _cashNoteMapper = new CashNoteMapper();
            _client = new ConsoleClient();
            _cashFlowAnalyzer = new CashFlowAnalyzer();
        }
        
        public void Start()
        {
            var isSessionOver = false;
            _client.Write(MenuMessage);
            
            while (!isSessionOver)
            {
                try
                {
                    var action = _client.GetAction();
                    PerformAction(action);

                    if (action == (int)Action.Exit)
                    {
                        isSessionOver = true;
                    }
                }
                catch (Exception e)
                {
                    _client.Write(e.Message);
                }
            }
        }
        
        private void PerformAction(int action)
        {
            switch (action)
            {
                case (int)Action.AddIncome:
                {
                    var moneyAmount = _client.GetMoneyAmount();
                    _cashFlowAnalyzer.AddNoteAboutIncome(moneyAmount);
                    _client.Write(AddingIsSuccessful); 
                    break;
                }
                case (int)Action.AddExpense:
                {
                    var moneyAmount = _client.GetMoneyAmount();
                    _cashFlowAnalyzer.AddNoteAboutExpense(moneyAmount);
                    _client.Write(AddingIsSuccessful);
                    break;
                }
                case (int)Action.ShowIncomes:
                {
                    _client.Write("Your incomes");
                    var table = _cashNoteMapper.MapCashNoteToTable(_cashFlowAnalyzer.Incomes);
                    _client.Write(table);
                    break;
                }
                case (int)Action.ShowExpenses:
                {
                    _client.Write("Your expenses");
                    var table = _cashNoteMapper.MapCashNoteToTable(_cashFlowAnalyzer.Expenses);
                    _client.Write(table);
                    break;
                }
            }
        }
    }
}