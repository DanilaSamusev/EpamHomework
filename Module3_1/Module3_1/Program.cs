﻿using System;

namespace Module3_1
{
    class Program
    {
        private const string FirstNumberQuery = "first number: ";
        private const string SecondNumberQuery = "second number: ";
        
        static void Main(string[] args)
        {
            int firstNumber = GetNumber(FirstNumberQuery);
            int secondNumber = GetNumber(SecondNumberQuery);

            int multiplication = Multiply(firstNumber, secondNumber);
            Console.WriteLine($"Multiplication result: {multiplication}");
        }

        static int GetNumber(string query)
        {
            while (true)
            {
                Console.Write($"Enter the {query}");
                bool isNumberParsed = int.TryParse(Console.ReadLine(), out int number);

                if (isNumberParsed)
                {
                    return number;
                }
                
                Console.WriteLine("Error: input data has to be an integer!\n-------------------------");
            }
        }

        static int Multiply(int firstNumber, int secondNumber)
        {
            int firstAbsoluteNumber = Math.Abs(firstNumber);
            int secondAbsoluteNumber = Math.Abs(secondNumber);
            int result = firstAbsoluteNumber;

            if (firstAbsoluteNumber == 0 || secondAbsoluteNumber == 0)
            {
                return 0;
            }
            
            for (var i = 1; i < secondAbsoluteNumber; i++)
            {
                result += firstAbsoluteNumber;
            }

            if ((firstNumber < 0 && secondNumber < 0)
                || (firstNumber > 0 && secondNumber > 0))
            {
                return result;
            }

            return MakeNumberNegative(result);
        }

        static int MakeNumberNegative(int number)
        {
            return number - (2 * number);
        }
    }
}