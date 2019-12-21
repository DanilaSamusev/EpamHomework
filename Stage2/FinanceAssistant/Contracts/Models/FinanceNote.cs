using System;

namespace Contracts.Models
{
    public class FinanceNote
    {
        public int Id { get; }
        public decimal FinanceAmount { get; }
        public DateTime CreationDate { get; }

        public FinanceNote(int id, decimal financeAmount, DateTime creationDate)
        {
            Id = id;
            FinanceAmount = financeAmount;
            CreationDate = creationDate;
        }
    }
}