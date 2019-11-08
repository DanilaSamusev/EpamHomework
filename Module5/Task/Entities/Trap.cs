namespace Task.Entities
{
    public class Trap
    {
        public int Damage { get; set; }
        public int Position { get; set; }
        public bool IsActive { get; set; }

        public Trap()
        {
            Damage = 0;
            Position = 0;
            IsActive = true;
        }
    }
}