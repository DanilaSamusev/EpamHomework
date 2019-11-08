namespace Task.Entities
{
    public class Cell
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public Cell(int id)
        {
            Id = id;
            Value = "O";
        }
    }
}