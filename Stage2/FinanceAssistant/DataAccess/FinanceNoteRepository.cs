using System.Collections.Generic;
using System.Linq;
using Contracts.Models;
using Contracts.RepositoryContracts;

namespace DataAccess
{
    public class FinanceNoteRepository : IFinanceNoteRepository
    {
        private static readonly List<FinanceNote> FinanceNotes = new List<FinanceNote>();
       
        public void Add(FinanceNote note)
        {          
            FinanceNotes.Add(note);
        }

        public IEnumerable<FinanceNote> GetAllExpenses()
        {
            return GetAll().Where(note => note.FinanceAmount < 0).ToList();
        }

        public IEnumerable<FinanceNote> GetAllIncomes()
        {
            return GetAll().Where(note => note.FinanceAmount > 0).ToList();
        }

        public IEnumerable<FinanceNote> GetAll()
        {
            return FinanceNotes;
        }
    }
}