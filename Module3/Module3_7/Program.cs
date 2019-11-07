using System;
using System.Collections;
using System.Collections.Generic;

namespace Module3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayInitializer = new ArrayInitializer();
            double[] array = arrayInitializer.InitializeArray();
            PrintIEnumerable(array, "Your array: ");
            var numbersList = GetNumbersFromArray(array);

            if (numbersList.Count > 1)
            {
                PrintIEnumerable(numbersList, "Required numbers: ");
            }
            else
            {
                Console.WriteLine("No numbers found");
            }
        }

        private static List<double> GetNumbersFromArray(double[] array)
        {
            var numbersList = new List<double>();

            for (var i = 1; i < array.Length; i++)
            {
                if (array[i] > array[i - 1])
                {
                    numbersList.Add(array[i]);
                }
            }

            return numbersList;
        }

        private static void PrintIEnumerable<T>(T array, string message) where T : IEnumerable
        {
            Console.Write($"{message}");

            foreach (var number in array)
            {
                Console.Write($" {number}");
            }

            Console.WriteLine();
        }
    }
}