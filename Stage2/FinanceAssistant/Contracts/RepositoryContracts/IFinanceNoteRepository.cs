using System.Collections.Generic;
using Contracts.Models;

namespace Contracts.RepositoryContracts
{
    public interface IFinanceNoteRepository : IRepository<FinanceNote>
    {
        IEnumerable<FinanceNote> GetAllExpenses();
        
        IEnumerable<FinanceNote> GetAllIncomes();

        IEnumerable<FinanceNote> GetAllByUserId(int userId);
    }
}