﻿using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Models;
using Contracts.RepositoryContracts;

namespace DataAccess
{
    public class FinanceNoteRepository : IFinanceNoteRepository
    {
        public void Add(decimal financeAmount)
        {
            var id = FinanceNotesStorage.FinanceNotes.Count;
            var note = new FinanceNote(id,financeAmount, DateTime.Now);
            FinanceNotesStorage.FinanceNotes.Add(note);
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
            return FinanceNotesStorage.FinanceNotes;
        }
    }
}