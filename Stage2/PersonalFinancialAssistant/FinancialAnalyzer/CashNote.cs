﻿using System;

 namespace FinancialAnalyzer
{
    public class CashNote
    {
        public long Id { get; }
        public decimal CashAmount { get; }
        public DateTime CreationDate { get; }

        public CashNote(long id, decimal cashAmount)
        {
            Id = id;
            CashAmount = cashAmount;
            CreationDate = DateTime.UtcNow;
        }
    }
}