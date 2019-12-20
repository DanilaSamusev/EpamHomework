using Models;
using System.Collections.Generic;

namespace RepositoryContracts
{
    public interface IFinanceNoteRepository
    {
         void Add(decimal financeAmount);

         IEnumerable<FinanceNote> GetAllExpences();

         IEnumerable<FinanceNote> GetAllIncomes();

         IEnumerable<FinanceNote> GetAll();
        
    }
}
