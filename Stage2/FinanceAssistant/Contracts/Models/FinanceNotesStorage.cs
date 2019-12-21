using System.Collections.Generic;

namespace Contracts.Models
{
    public static class FinanceNotesStorage
    {
        public static readonly List<FinanceNote> FinanceNotes;

        static FinanceNotesStorage()
        {
            FinanceNotes = new List<FinanceNote>();
        }
    }
}