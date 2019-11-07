using System;

namespace Module3_8
{
    public class MatrixFiller
    {
        private int ColumnNumber { get; set; }
        private int RowNumber { get; set; }
        private Direction Direction { get; set; }
        private int[,] Matrix { get; set; }
        private int Value { get; set; }

        public void FillMatrixInSpiral(int[,] matrix)
        {
            ColumnNumber = 0;
            RowNumber = 0;
            Direction = Direction.Right;
            Matrix = matrix;
            int iterationsNumber = matrix.Length;
            Matrix[RowNumber, ColumnNumber] = 1;

            for (Value = 2; Value <= iterationsNumber;)
            {
                if (Direction == Direction.Right)
                {
                    if (TryFill(ColumnNumber + 1, RowNumber))
                    {
                        ColumnNumber++;
                    }
                }

                if (Direction == Direction.Bottom)
                {
                    if (TryFill(ColumnNumber, RowNumber + 1))
                    {
                        RowNumber++;
                    }
                }

                if (Direction == Direction.Left)
                {
                    if (TryFill(ColumnNumber - 1, RowNumber))
                    {
                        ColumnNumber--;
                    }
                }

                if (Direction == Direction.Top)
                {
                    if (TryFill(ColumnNumber, RowNumber - 1))
                    {
                        RowNumber--;
                    }
                }
            }
        }
        
        private bool TryFill(int columnNumber, int rowNumber)
        {
            try
            {
                if (Matrix[rowNumber, columnNumber] != 0)
                {
                    throw new Exception();
                }
                
                Matrix[rowNumber, columnNumber] = Value;
                Value++;
                return true;
            }
            catch
            {
                ChangeDirection();
                return false;
            }
        }
        private void ChangeDirection()
        {
            switch (Direction)
            {
                case Direction.Right:
                    Direction = Direction.Bottom;
                    return;
                case Direction.Bottom:
                    Direction = Direction.Left;
                    return;
                case Direction.Left:
                    Direction = Direction.Top;
                    return;
                case Direction.Top:
                    Direction = Direction.Right;
                    break;
            }
        }
    }
}