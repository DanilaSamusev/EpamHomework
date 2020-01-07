using System;

namespace Contracts.Models
{
    public class FinanceNote
    {
        public int UserId { get; set; }
        public decimal FinanceAmount { get; set;}
        public DateTime CreationDate { get; set;}
    }
}