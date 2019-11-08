using System;
using System.Linq;
using Task.Entities;

namespace Task
{
    public class GameViewer
    {
        private const int FieldWidth = 10;
        private const int RightFieldBorder = 9;
        public void DisplayField(DataToView dataToView)
        {
            Console.Clear();
            Console.WriteLine($"HP: {dataToView.Player.Hp}");

            var cells = dataToView.Cells;

            for (var i = 0; i < cells.Length; i++)
            {
                var cellValue = GetCellValue(dataToView, i);

                Console.Write($"{cellValue}   ");
                
                if (IsNewLineRequired(i))
                {
                    Console.WriteLine();
                }
            }
        }

        private string GetCellValue(DataToView dataToView, int id)
        {
            if (dataToView.Player.Position == id)
            {
                return "+";
            }

            Trap requiredTrap = dataToView.Traps.FirstOrDefault(trap => trap.Position == id);

            if (requiredTrap != null)
            {
                if (!requiredTrap.IsActive)
                {
                    return "*";
                }
            }

            return dataToView.Princes.Position == id ? "W" : "0";
        }

        private static bool IsNewLineRequired(int cellId)
        {
            return cellId % FieldWidth == RightFieldBorder;
        }
    }
}