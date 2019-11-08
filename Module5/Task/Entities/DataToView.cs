namespace Task.Entities
{
    public class DataToView
    {
        public Cell[] Cells { get; set; }
        public Trap[] Traps { get; set; }
        public Player Player { get; set; }
        public Princes Princes { get; set; }

        public DataToView(Cell[] cells, Trap[] traps, Player player, Princes princes)
        {
            Cells = cells;
            Traps = traps;
            Player = player;
            Princes = princes;
        }
    }
}