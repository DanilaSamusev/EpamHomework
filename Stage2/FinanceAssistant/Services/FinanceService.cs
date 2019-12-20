using Models;
using ServiceContracts;
using RepositoryContracts;
using System.Collections.Generic;

namespace Services
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

        public IEnumerable<FinanceNote> GetAllExpences()
        {
            return _finaceNoteRepository.GetAllExpences();
        }             

        private decimal WithdrawTaxes(decimal financeAmount)
        {
            return financeAmount - (financeAmount / 100 * TaxRateInPercent);
        }
    }
}
