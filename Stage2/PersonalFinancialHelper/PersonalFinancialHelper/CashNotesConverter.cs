using System.Collections.Generic;
using System.Linq;

namespace PersonalFinancialHelper
{
    public class CashNotesConverter
    {
        public string GetNotesAsTable(IEnumerable<CashNote> notes)
        {
            var maxIdLength = notes.Count().ToString().Length;
            var maxCashAmountLength =
                notes.OrderByDescending(note => note.CashAmount).First().CashAmount.ToString().Length;
            var tableHead = "-------------------------\n" +
                            $" {Constants.Id}{MakeSpaces(maxIdLength - Constants.Id.Length)} |" +
                            $" {Constants.Cash}{MakeSpaces(maxCashAmountLength - Constants.Cash.Length)} |" +
                            $" {Constants.Date}{MakeSpaces(Constants.Date.Length)}\n" +
                            "-------------------------\n";
            var tableBody = "";

            foreach (var cashNote in notes)
            {
                var tableRow = $" {cashNote.Id} " +
                               $"{MakeSpaces(maxIdLength - cashNote.Id.ToString().Length)} |" +
                               $" {cashNote.CashAmount} " +
                               $"{MakeSpaces(maxCashAmountLength - cashNote.CashAmount.ToString().Length)} |" +
                               $" {cashNote.CreationDate:dd.MM.yyyy}" +
                               $"{MakeSpaces(Constants.Date.Length - cashNote.CreationDate.ToString().Length)}";
                tableBody += $"{tableRow}\n";
            }

            return tableHead + tableBody;
        }

        private string MakeSpaces(int spacesCount)
        {
            var spaces = "";

            for (var i = 0; i < spacesCount; i++)
            {
                spaces += " ";
            }

            return spaces;
        }
    }
}