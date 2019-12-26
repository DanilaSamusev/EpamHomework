using System;
using Contracts.RepositoryContracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Contracts.Models;

namespace DataAccess
{
    public class FinanceNoteJsonRepository : IFinanceNoteRepository
    {
        private readonly string _connectionString;

        public FinanceNoteJsonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(decimal financeAmount)
        {
            var note = new FinanceNote
            {
                CreationDate = new DateTime(),
                FinanceAmount = financeAmount,
            };
            
            var financeNotes = GetAll().ToList();
            financeNotes.Add(note);
            File.WriteAllText(_connectionString, JsonSerializer.Serialize(financeNotes));
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
            
            var notes = File.ReadAllText(_connectionString);
            
            return JsonSerializer.Deserialize<List<FinanceNote>>(notes);;
        }
    }
}