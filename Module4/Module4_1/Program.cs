using System;

namespace Module4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = {1, 2, 13, 4, 5, 8, 3, 3, 9, 2, 11, 10, 5};

            double max = FindMaxInArray(array);
            double min = FindMinInArray(array);
            double sum = FindArraySum(array);
            double subtraction = FindMinAndMaxSubtraction(array);
            Console.WriteLine($"Maximal value is: {max}");
            Console.WriteLine($"Minimal value is: {min}");
            Console.WriteLine($"Array sum is: {sum}");
            Console.WriteLine($"max - min = {subtraction}");
            ChangeArray(array);
            DisplayArray(array);
        }

        static double FindMaxInArray(double[] array)
        {
            double max = array[0];

            foreach (var number in array)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            return max;
        }

        static double FindMinInArray(double[] array)
        {
            double min = array[0];

            foreach (var number in array)
            {
                if (number < min)
                {
                    min = number;
                }
            }

            return min;
        }   

        static double FindArraySum(double[] array)
        {
            double sum = 0;

            foreach (var number in array)
            {
                sum += number;
            }

            return sum;
        }

        static double FindMinAndMaxSubtraction(double[] array)
        {

            return FindMaxInArray(array) - FindMinInArray(array);
        }

        static void ChangeArray(double[] array)
        {
            double max = FindMaxInArray(array);
            double min = FindMinInArray(array);

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    array[i] += max;
                }
                else
                {
                    array[i] -= min;
                }
            }
        }

        static void DisplayArray(double[] array)
        {
            Console.WriteLine("New array is: ");
            
            foreach (var number in array)
            {
                Console.Write($"{number} ");
            }
        }
    }
}