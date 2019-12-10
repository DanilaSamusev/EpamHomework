using System;
using Client.Interfaces;
using FinancialService;

namespace Client
{
    public class ConsoleClient : IClient
    {
        private readonly IWriter _writer;
        private readonly IReader _reader;
        private readonly IFinancialService _financialService;
        private readonly FinancialNoteMapper _financialNoteMapper;

        private const string MenuMessage = "If you want to add an income press 1\n" +
                                           "to add an expense press 2\n" +
                                           "to see all your incomes press 3\n" +
                                           "to see all your expenses press 4\n" +
                                           "to see your total financial flow press 5\n" +
                                           "to finish session press 6\n";

        private const string AddingIsSuccessful = "Data has been added.";

        public ConsoleClient(IWriter writer, IReader reader, IFinancialService financialService,
            FinancialNoteMapper financialNoteMapper)
        {
            _writer = writer;
            _reader = reader;
            _financialService = financialService;
            _financialNoteMapper = financialNoteMapper;
        }

        public void Run()
        {
            _writer.Write(MenuMessage);
            var isSessionOver = false;

            while (!isSessionOver)
            {
                try
                {
                    var action = GetAction();
                    PerformAction(action);

                    if (action == (int) Action.Exit)
                    {
                        isSessionOver = true;
                    }
                }
                catch (Exception e)
                {
                    _writer.Write(e.Message);
                }
            }
        }

        public int GetAction()
        {
            _writer.Write("Enter required key: ");
            var action = _reader.Read();
            var isActionParsed = int.TryParse(action, out var parsedAction);

            if (isActionParsed)
            {
                return parsedAction;
            }

            throw new ArgumentException("Error! Check entered value.");
        }

        public decimal GetFinanceAmount()
        {
            _writer.Write("Inter finance amount: ");
            var financeAmount = _reader.Read();
            var isFinanceAmountParsed = decimal.TryParse(financeAmount, out var parsedFinanceAmount);

            if (isFinanceAmountParsed)
            {
                return parsedFinanceAmount;
            }

            throw new ArgumentException("Number has to be a positive.");
        }

        private void PerformAction(int action)
        {
            switch (action)
            {
                case (int) Action.AddIncome:
                {
                    var financeAmount = GetFinanceAmount();
                    _financialService.AddIncome(financeAmount);
                    _writer.Write(AddingIsSuccessful);
                    break;
                }
                case (int) Action.AddExpense:
                {
                    var financeAmount = GetFinanceAmount();
                    _financialService.AddExpense(financeAmount);
                    _writer.Write(AddingIsSuccessful);
                    break;
                }
                case (int) Action.ShowIncomes:
                {
                    _writer.Write("Your incomes:");
                    var financialNotesDto = _financialService.GetAllIncomes();
                    var table = _financialNoteMapper.MapFinancialNotesToTable(financialNotesDto);
                    _writer.Write(table);
                    break;
                }
                case (int) Action.ShowExpenses:
                {
                    _writer.Write("Your expenses:");
                    var financialNotesDto = _financialService.GetAllExpenses();
                    var table = _financialNoteMapper.MapFinancialNotesToTable(financialNotesDto);
                    _writer.Write(table);
                    break;
                }
                case (int) Action.ShowTotalFinancialFlow:
                {
                    _writer.Write("Your financial flow:");
                    var totalFinancialFlow = _financialService.GetTotalFinancialFlow();
                    _writer.Write(totalFinancialFlow.ToString());
                    break;
                }
            }
        }
    }
}