using Contracts.RepositoryContracts;

namespace Business.FinanceAnalyzer
{
    public class FinanceAnalyzer
    {
        private readonly IFinanceNoteRepository _financeNoteRepository;
        
        public FinanceAnalyzer(IFinanceNoteRepository financeNoteRepository)
        {
            _financeNoteRepository = financeNoteRepository;
        }

        public decimal GetTotalFinanceFlow()
        {
            decimal financeFlow = 0;
            var notes = _financeNoteRepository.GetAll();

            foreach(var note in notes)
            {
                financeFlow += note.FinanceAmount;
            }

            return financeFlow;
        }
    }
}