using System;

namespace FinancialService
{
    public class FinancialNoteDto
    {
        public long Id { get; set; }
        public decimal FinanceAmount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}