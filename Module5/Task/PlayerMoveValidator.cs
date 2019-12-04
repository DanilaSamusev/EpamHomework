namespace Task
{
    public static class PlayerMoveValidator
    {
        public static bool CanPlayerMove(int currentPlayerPosition, int nextPlayerPosition)
        {
            if (nextPlayerPosition >= 0 && nextPlayerPosition <= 99)
            {
                return MoveIsValidForLines(currentPlayerPosition, nextPlayerPosition);
            }

            return false;
        }
        
        private static bool MoveIsValidForLines(int currentPlayerPosition, int nextPlayerPosition)
        {

            switch (currentPlayerPosition % 10)
            {
                case 0:
                    return nextPlayerPosition != currentPlayerPosition - 1;
                case 9:
                    return nextPlayerPosition != currentPlayerPosition + 1;
                default:
                    return true;
            }
        }
    }
}