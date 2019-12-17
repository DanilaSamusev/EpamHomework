using Models;
using System.Collections.Generic;

namespace RepositoryContracts
{
    public interface IFinanceNoteRepository
    {
        void Add(FinanceNote note);
        IEnumerable<FinanceNote> GetAll();
    }
}
