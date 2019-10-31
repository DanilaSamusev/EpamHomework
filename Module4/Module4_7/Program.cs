using System;

namespace Module4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = {1, 4, 2, 3, 9, 2, 1, 5};
            Console.Write("Your array: ");
            DisplayArray(array);
            string sortDirection = GetSortDirection();
            SortArray(array, sortDirection);
            Console.Write("Sorted array: ");
            DisplayArray(array);
        }

        static string GetSortDirection()
        {
            while (true)
            {
                Console.Write("Enter sort direction: up or down - ");
                string direction = Console.ReadLine();

                if (direction == "up" || direction == "down")
                {
                    return direction;
                }
            
                Console.WriteLine("Error: check input data!");  
            }
        }
        
        static void SortArray(double[] array, string direction)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length - 1; j++)
                {

                    if (array[j] > array[j + 1])
                    {
                        double temporary = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temporary;
                    }
                }
            }

            if (direction == "down")
            {
                Array.Reverse(array);
            }
        }

        static void DisplayArray(double[] array)
        {
            foreach (var number in array)
            {
                Console.Write($"{number} ");
            }
            
            Console.WriteLine();
        }
    }
}