using RepositoryContracts;

namespace FinanceAnalizer
{
    public class FinanceFlowAnalizer
    {
        private readonly IFinanceNoteRepository _financeNoteRepository;
        public FinanceFlowAnalizer(IFinanceNoteRepository financeNoteRepository)
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
