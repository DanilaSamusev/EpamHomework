using System;
using System.Linq;

namespace Module4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 0;
            int secondNumber = 4;
            int thirdNumber = 6;
            int[] array = { 1, 2, 3};
            Increase(ref firstNumber, ref secondNumber, ref thirdNumber);
            Console.WriteLine($"{firstNumber} {secondNumber} {thirdNumber}");
            CountCircleLengthAndArea(4, out double length, out double area);
            Console.WriteLine($"length : {length}, area: {area}");
            FindMaxAndMinAndArraySum(array, out int max, out int min, out int sum);
            Console.WriteLine($"max: {max}, min {min}, sum {sum}");
        }

        static void Increase(ref int firstNumber, ref int secondNumber, ref int thirdNumber)
        {
            int coefficient = 10;
            firstNumber += coefficient;
            secondNumber += coefficient;
            thirdNumber += coefficient;
        }

        static void CountCircleLengthAndArea(int radius, out double length, out double area)
        {
            length = 2 * Math.PI * radius;
            area = Math.PI * Math.Pow(radius, 2);
        }

        static void FindMaxAndMinAndArraySum(int[] array, out int max, out int min, out int sum)
        {
            max = array.Max();
            min = array.Min();
            sum = array.Sum();
        }
    }
}