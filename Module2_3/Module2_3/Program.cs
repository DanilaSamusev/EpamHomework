using System;

namespace Module2_3
{
    class Program
    {
        private const string FirstNumberQuery = "first number: ";
        private const string SecondNumberQuery = "second number: ";

        static void Main(string[] args)
        {
            double firstNumber = GetNumber(FirstNumberQuery);
            double secondNumber = GetNumber(SecondNumberQuery);

            Console.WriteLine($"Before swap: first number - {firstNumber}; second number - {secondNumber}");
            Swap(ref firstNumber, ref secondNumber);
            Console.WriteLine($"After swap: first number - {firstNumber}; second number - {secondNumber}");
        }

        static double GetNumber(string query)
        {
            while (true)
            {
                Console.Write($"Enter the {query}");
                string number = Console.ReadLine();
                string formattedNumber = number.Replace(',', '.');

                if (double.TryParse(formattedNumber, out double parsedNumber))
                {
                    return parsedNumber;
                }

                Console.WriteLine("Error: input data has to be a decimal\n---------------------------");
            }
        }

        static void Swap(ref double firstNumber, ref double secondNumber)
        {
            double temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
    }
}