using System.Collections.Generic;
using Contracts.Models;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;

namespace Business.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IFinanceNoteRepository _finaceNoteRepository;
        private const decimal TaxRateInPercent = 13;

        public FinanceService(IFinanceNoteRepository finaceNoteRepository)
        {
            _finaceNoteRepository = finaceNoteRepository;
        }

        public void AddExpenseNote(decimal financeAmount)
        {            
            _finaceNoteRepository.Add(-financeAmount);
        }

        public void AddIncomeNote(decimal financeAmount)
        {
            financeAmount = WithdrawTaxes(financeAmount);
            _finaceNoteRepository.Add(financeAmount);
        }

        public IEnumerable<FinanceNote> GetAllIncomes()
        {
            return _finaceNoteRepository.GetAllIncomes();
        }

        public IEnumerable<FinanceNote> GetAllExpenses()
        {
            return _finaceNoteRepository.GetAllExpenses();
        }             

        private decimal WithdrawTaxes(decimal financeAmount)
        {
            return financeAmount - (financeAmount / 100 * TaxRateInPercent);
        }
    }
}