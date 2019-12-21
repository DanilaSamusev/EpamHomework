﻿using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.ServiceContracts
{
    public interface IFinanceService
    {
        void AddExpenseNote(decimal financeAmount);

        void AddIncomeNote(decimal financeAmount);

        IEnumerable<FinanceNote> GetAllIncomes();

        IEnumerable<FinanceNote> GetAllExpenses();
    }
}