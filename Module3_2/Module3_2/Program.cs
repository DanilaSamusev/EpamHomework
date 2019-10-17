﻿using System;

namespace Module3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber("number: ");
            PrintNumbers(number);
        }
        
        static int GetNumber(string query)
        {
            while (true)
            {
                Console.Write($"Inter the {query}");
                bool isNumberParsed = int.TryParse(Console.ReadLine(), out int number);

                if (isNumberParsed)
                {
                    return number;
                }
                
                Console.WriteLine("Error: input data has to be an integer\n-------------------------");
            }
        }

        static void PrintNumbers(int numbersCount)
        {
            Console.Write("result: ");
            
            for (var i = 1; i <= numbersCount; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}