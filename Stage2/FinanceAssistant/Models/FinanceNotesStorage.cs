using System.Collections.Generic;

namespace Models
{
    public class FinanceNotesStorage
    {
        public static List<FinanceNote> FinanceNotes;

        static FinanceNotesStorage()
        {
            FinanceNotes = new List<FinanceNote>();
        }
    }
}
