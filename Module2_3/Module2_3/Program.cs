using System;

namespace Module2_3
{
    class Program
    {
        private const string FirstNumberQuery = "first number: ";
        private const string SecondNumberQuery = "second number: ";

        static void Main(string[] args)
        {
            string firstNumber = GetNumber(FirstNumberQuery);
            string secondNumber = GetNumber(SecondNumberQuery);

            Console.WriteLine($"Before swap: first number - {firstNumber}; second number - {secondNumber}");
            Swap(ref firstNumber, ref secondNumber);
            Console.WriteLine($"After swap: first number - {firstNumber}; second number - {secondNumber}");
        }

        static string GetNumber(string query)
        {
            while (true)
            {
                Console.Write($"Inter the {query}");
                string number = Console.ReadLine();
                string formattedNumber = number.Replace(',', '.');

                if (IsNumberValid(formattedNumber))
                {
                    return number;
                }

                Console.WriteLine("Error: input data has to be a decimal\n---------------------------");
            }
        }

        static bool IsNumberValid(string number)
        {
            if (number[0].Equals('.'))
            {
                return false;
            }
            
            bool isNumberParsed = double.TryParse(number, out double parsedNumber);
            return isNumberParsed;
        }
        
        static void Swap(ref string firstNumber, ref string secondNumber)
        {
            string temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
    }
}