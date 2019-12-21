using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.RepositoryContracts
{
    public interface IFinanceNoteRepository
    {
        void Add(decimal financeAmount);

        IEnumerable<FinanceNote> GetAllExpenses();

        IEnumerable<FinanceNote> GetAllIncomes();

        IEnumerable<FinanceNote> GetAll();
    }
}