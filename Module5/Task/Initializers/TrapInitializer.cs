using System;
using System.Linq;
using Task.Entities;

namespace Task.Initializers
{
    public class TrapInitializer
    {
        private const int TrapsCount = 10;
        private const int MaxTrapDamage = 10;
        private const int MinTrapDamage = 1;
        private const int MinTrapPosition = 1;
        private const int MaxTrapPosition = 98;
        
        public Trap[] InitializeTraps()
        {
            var traps = InitializeDefaultTraps();
            var random = new Random();

            for (var i = 0; i < traps.Length; i++)
            {
                var damage = random.Next(MinTrapDamage, MaxTrapDamage);
                var position = 0;
                
                do
                {
                    position = random.Next(MinTrapPosition, MaxTrapPosition);
                } while (traps.FirstOrDefault(trap => trap.Position == position) != null);

                traps[i].Damage = damage;
                traps[i].Position = position;
            }

            return traps;
        }

        public Trap[] InitializeDefaultTraps()
        {
            var traps = new Trap[TrapsCount];

            for (var i = 0; i < traps.Length; i++)
            {
                traps[i] = new Trap();
            }

            return traps;
        }
    }
}