using System.Collections.Generic;
using Contracts.Models;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;

namespace Business.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IFinanceNoteRepository _financeNoteRepository;
        private const decimal TaxRateInPercent = 13;

        public FinanceService(IFinanceNoteRepository financeNoteRepository)
        {
            _financeNoteRepository = financeNoteRepository;
        }

        public void AddExpenseNote(decimal financeAmount)
        {            
            _financeNoteRepository.Add(-financeAmount);
        }

        public void AddIncomeNote(decimal financeAmount)
        {
            financeAmount = WithdrawTaxes(financeAmount);
            _financeNoteRepository.Add(financeAmount);
        }

        public IEnumerable<FinanceNote> GetAllIncomes()
        {
            return _financeNoteRepository.GetAllIncomes();
        }

        public IEnumerable<FinanceNote> GetAllExpenses()
        {
            return _financeNoteRepository.GetAllExpenses();
        }             

        private decimal WithdrawTaxes(decimal financeAmount)
        {
            return financeAmount - (financeAmount / 100 * TaxRateInPercent);
        }
    }
}