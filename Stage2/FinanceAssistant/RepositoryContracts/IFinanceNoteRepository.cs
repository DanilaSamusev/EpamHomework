using Models;
using System.Collections.Generic;

namespace RepositoryContracts
{
    public interface IFinanceNoteRepository
    {

        void Add(decimal financeAmount);

        public IEnumerable<FinanceNote> GetAllExpences();

        public IEnumerable<FinanceNote> GetAllIncomes();

        IEnumerable<FinanceNote> GetAll();
    }
}
