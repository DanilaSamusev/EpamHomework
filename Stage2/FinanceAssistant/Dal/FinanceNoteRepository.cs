using Models;
using System;
using System.Linq;
using RepositoryContracts;
using System.Collections.Generic;

namespace Repositories
{
    public class FinanceNoteRepository : IFinanceNoteRepository
    {

        public void Add(decimal financeAmount)
        {
            var id = FinanceNotesStorage.FinanceNotes.Count;
            var note = new FinanceNote(id,financeAmount, DateTime.Now);
            FinanceNotesStorage.FinanceNotes.Add(note);
        }

        public IEnumerable<FinanceNote> GetAllExpences()
        {
            return GetAll().Where(note => note.FinanceAmount < 0).ToList();
        }

        public IEnumerable<FinanceNote> GetAllIncomes()
        {
            return GetAll().Where(note => note.FinanceAmount > 0).ToList();
        }

        public IEnumerable<FinanceNote> GetAll()
        {
            return FinanceNotesStorage.FinanceNotes;
        }
    }       
}
