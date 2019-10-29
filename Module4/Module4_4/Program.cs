using System;
using System.Linq;

namespace Module4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Increase(1, 2, 3));
            Console.WriteLine(CountCircleLengthAndArea(4));
            Console.WriteLine(FindMaxAndMinAndArraySum(new []{1, 2, 3}));
        }

        static (int, int, int) Increase(int firstNumber, int secondNumber, int thirdNumber)
        {
            const int coefficient = 10;
            return (firstNumber + coefficient, secondNumber + coefficient, thirdNumber + coefficient);
        }

        static (double, double) CountCircleLengthAndArea(int radius)
        {
            double length = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);
            return (length, area);
        }

        static (int, int, int) FindMaxAndMinAndArraySum(int[] array)
        {
            int max = array.Max();
            int min = array.Min();
            int sum = array.Sum();

            return (max, min, sum);
        }
        
    }
}