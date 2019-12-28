using System;
using System.Collections.Generic;
using Contracts.Models;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;

namespace Business.Services
{
    public class FinanceNoteNoteService : IFinanceNoteService
    {
        private readonly IFinanceNoteRepository _financeNoteRepository;
        private const decimal TaxRateInPercent = 13;

        public FinanceNoteNoteService(IFinanceNoteRepository financeNoteRepository)
        {
            _financeNoteRepository = financeNoteRepository;
        }

        public void AddExpenseNote(decimal financeAmount)
        {
            var note = new FinanceNote
            {
                CreationDate = DateTime.Now,
                FinanceAmount = -financeAmount,
            };

            _financeNoteRepository.Add(note);
        }

        public void AddIncomeNote(decimal financeAmount)
        {
            financeAmount = WithdrawTaxes(financeAmount);

            var note = new FinanceNote
            {
                CreationDate = DateTime.Now,
                FinanceAmount = -financeAmount,
            };

            _financeNoteRepository.Add(note);
        }

        public IEnumerable<FinanceNote> GetAllIncomes()
        {
            return _financeNoteRepository.GetAllIncomes();
        }

        public IEnumerable<FinanceNote> GetAllExpenses()
        {
            return _financeNoteRepository.GetAllExpenses();
        }

        public IEnumerable<FinanceNote> GetAllNotes()
        {
            return _financeNoteRepository.GetAll();
        }

        private decimal WithdrawTaxes(decimal financeAmount)
        {
            return financeAmount - (financeAmount / 100 * TaxRateInPercent);
        }
    }
}