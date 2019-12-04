using System;
using System.Linq;
using Task.Initializers;

namespace Task.Entities
{
    public class Game
    {
        private readonly GameViewer _gameViewer;
        private readonly DataToView _dataToView;

        public Game()
        {
            _gameViewer = new GameViewer();
            var trapCreator = new TrapInitializer();
            IsGameFinished = false;
            Field = new Field();
            Player = new Player();
            Princes = new Princes();
            Traps = trapCreator.InitializeTraps();
            _dataToView = new DataToView(Field.Cells, Traps, Player, Princes);
        }

        public bool Start()
        {
            while (!IsGameFinished)
            {
                _gameViewer.DisplayField(_dataToView);
                var moveKey = Console.ReadKey().Key;
                MovePlayer(moveKey);
                HandlePlayerMove();
            }

            return IsAnotherGameRequired();
        }

        private void MovePlayer(ConsoleKey moveKey)
        {
            int currentPlayerPosition = Player.Position;
            int nextPlayerPosition = currentPlayerPosition;

            switch (moveKey)
            {
                case ConsoleKey.LeftArrow:
                {
                    nextPlayerPosition = currentPlayerPosition - 1;
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    nextPlayerPosition = currentPlayerPosition - 10;
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    nextPlayerPosition = currentPlayerPosition + 1;
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    nextPlayerPosition = currentPlayerPosition + 10;
                    break;
                }
            }

            if (PlayerMoveValidator.CanPlayerMove(currentPlayerPosition, nextPlayerPosition))
            {
                Player.Move(nextPlayerPosition);
            }
        }

        private void HandlePlayerMove()
        {
            var currentTrap = Traps.FirstOrDefault(trap => trap.Position == Player.Position);

            if (currentTrap != null && currentTrap.IsActive)
            {
                HitPlayer(currentTrap.Damage);
                _gameViewer.DisplayField(_dataToView);
                Console.WriteLine($"Boom! You've lost {currentTrap.Damage} hp!\nPress any key to continue");
                Console.ReadKey();
                DeactivateTrap(currentTrap);
            }

            if (Player.Hp <= 0)
            {
                FinishGameWithMessage("loose");
            }

            if (Player.Position == Princes.Position)
            {
                FinishGameWithMessage("win");
            }
        }

        private void DeactivateTrap(Trap trap)
        {
            trap.IsActive = false;
        }

        private void HitPlayer(int damage)
        {
            if (Player.Hp < damage)
            {
                Player.Hp = 0;
            }
            else
            {
                Player.Hp -= damage;
            }
        }

        private void FinishGameWithMessage(string message)
        {
            IsGameFinished = true;
            Console.WriteLine($"You {message}!\nAnother game?\nEnter - yes; Esc - no");
        }

        private bool IsAnotherGameRequired()
        {
            while (true)
            {
                var gameStateKey = Console.ReadKey();

                switch (gameStateKey.Key)
                {
                    case ConsoleKey.Escape:
                    {
                        return false;
                    }
                    case ConsoleKey.Enter:
                    {
                        return true;
                    }
                }
            }
        }

        public Field Field { get; set; }
        public Player Player { get; set; }
        public Princes Princes { get; set; }
        public Trap[] Traps { get; set; }
        public bool IsGameFinished { get; set; }
    }
}