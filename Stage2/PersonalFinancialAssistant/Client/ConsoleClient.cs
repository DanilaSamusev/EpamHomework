using System;
using Client.Interfaces;

namespace Client
{
    public class ConsoleClient : IClient
    {
        private readonly IWriter _writer;
        private readonly IReader _reader;

        public ConsoleClient()
        {
            _writer = new ConsoleWriter();
            _reader = new ConsoleReader();
        }
        
        public void Write(string message)
        {
            _writer.Write(message);
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
        
        public decimal GetMoneyAmount()
        {
            _writer.Write("Inter cash amount: ");
            var financeAmount = _reader.Read();
            var isFinanceAmountParsed = decimal.TryParse(financeAmount, out var parsedFinanceAmount);
            
            if (isFinanceAmountParsed)
            {
                return parsedFinanceAmount;
            }
            
            throw new ArgumentException("Number has to be a positive.");
        }
    }
}