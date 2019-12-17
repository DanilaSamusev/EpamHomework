using System.Collections.Generic;

namespace Models
{
    public static class FinanceNotesStorage
    {
        public static IEnumerable<FinanceNote> FinanceNotes;

        static FinanceNotesStorage()
        {
            FinanceNotes = new List<FinanceNote>();
        }
    }
}
