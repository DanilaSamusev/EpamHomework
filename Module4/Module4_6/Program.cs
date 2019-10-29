using System;

namespace Module4_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = {1, 3, 5.1, 42};
            Console.Write("Your array: ");
            DisplayArray(array);
            IncreaseArray(array);
            Console.WriteLine();
            Console.Write("Increased array: ");
            DisplayArray(array);
        }

        static void IncreaseArray(double[] array)
        {
            const int coefficient = 5;

            for (var i = 0; i < array.Length; i++)
            {
                array[i] += coefficient;
            }
        }

        static void DisplayArray(double[] array)
        {
            foreach (var number in array)
            {
                Console.Write($"{number} ");
            }
        }
    }
}