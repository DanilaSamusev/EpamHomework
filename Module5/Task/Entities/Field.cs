namespace Task.Entities
{
    public class Field
    {
        private const int CellsCount = 100; 
        public Cell[] Cells { get; set; }
        public Field()
        {
            Cells = InitializeCells();
        }
        
        private Cell[] InitializeCells()
        {
            Cell[] cells = new Cell[CellsCount];
            
            for (var i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell(i);
            }

            return cells;
        }
    }
}