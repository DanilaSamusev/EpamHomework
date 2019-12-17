using System.Collections.Generic;

namespace Models
{
    public class FinanceFlowStorage
    {
        public List<FinancialNote> Incomes { get; }
        public List<FinancialNote> Expenses { get; }
    }
}
