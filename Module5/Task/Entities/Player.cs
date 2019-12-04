namespace Task.Entities
{
    public class Player
    {
        private const int PlayerHp = 10;
        private const int PlayerStartPosition = 0;
        public int Hp { get; set; }
        public int Position { get; private set; }
        
        public Player()
        {
            Hp = PlayerHp;
            Position = PlayerStartPosition;
        }

        public void Move(int nextPlayerPosition)
        {
            Position = nextPlayerPosition;
        }
    }
}