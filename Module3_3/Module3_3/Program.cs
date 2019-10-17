﻿using System;

namespace Module3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber("number: ");
            PrintFibonacci(number);
        }
        
        static int GetNumber(string query)
        {
            while (true)
            {
                Console.Write($"Inter the {query}");
                bool isNumberParsed = int.TryParse(Console.ReadLine(), out int number);

                if (isNumberParsed && number > 0)
                {
                    return number;
                }
                
                Console.WriteLine("Error: input data has to be a positive integer\n-------------------------");
            }
        }

        static void PrintFibonacci(int numbersCount)
        {
            int temp1 = 0;
            int temp2 = 1;
            
            Console.Write($"result: {temp1}");
            
            if (numbersCount == 1)
            {
                return;
            }

            Console.Write($" {temp2}");
            
            for (var i = 3; i <= numbersCount; i++)
            {
                int currentNumber = temp1 + temp2;
                temp1 = temp2;
                temp2 = currentNumber;
                Console.Write($" {currentNumber}");
            }
        }
    }
}