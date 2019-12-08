﻿using System;

 namespace FinancialAnalyzer
{
    public class FinanceNote
    {
        public long Id { get; }
        public decimal FinanceAmount { get; }
        public DateTime CreationDate { get; }

        public FinanceNote(long id, decimal financeAmount)
        {
            Id = id;
            FinanceAmount = financeAmount;
            CreationDate = DateTime.UtcNow;
        }
    }
}