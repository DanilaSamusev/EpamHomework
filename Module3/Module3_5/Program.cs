using System;

namespace Module3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber();
            int digit = GetDigit();
            int reformedNumber = int.Parse(number.ToString().Replace($"{digit}", ""));
            Console.WriteLine($"New number is: {reformedNumber}");
        }

        static int GetNumber()
        {
            while (true)
            {
                Console.Write("Enter the the number: ");
                
                if (int.TryParse(Console.ReadLine(), out int parsedNumber) && parsedNumber > 0)
                {
                    return parsedNumber;
                }

                Console.WriteLine("Error: input data has to be a positive integer!\n-------------------------");
            }
        }

        static int GetDigit()
        {
            while (true)
            {
                Console.Write("Inter the the digit: ");

                if (int.TryParse(Console.ReadLine(), out int parsedDigit) 
                    && parsedDigit < 10 && parsedDigit >= 0)
                {
                    return parsedDigit;
                }

                Console.WriteLine("Error: input data has to be a digit!\n-------------------------");
            }
        }
    }
}