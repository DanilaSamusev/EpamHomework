﻿using System;

 namespace FinancialAnalyzer
{
    public class FinancialNote
    {
        public long Id { get; }
        public decimal FinanceAmount { get; }
        public DateTime CreationDate { get; }

        public FinancialNote(long id, decimal financeAmount)
        {
            Id = id;
            FinanceAmount = financeAmount;
            CreationDate = DateTime.UtcNow;
        }
    }
}