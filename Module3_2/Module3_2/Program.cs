﻿using System;

namespace Module3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber();
            PrintNumbers(number);
        }
        
        static int GetNumber()
        {
            while (true)
            {
                Console.Write("Enter the number: ");

                if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                {
                    return number;
                }
                
                Console.WriteLine("Error: input data has to be a positive integer!\n-------------------------");
            }
        }

        static void PrintNumbers(int numbersCount)
        {
            Console.Write("result: ");
            var number = 2;
            
            for (var i = 1; i <= numbersCount;)
            {
                if (number % 2 == 0)
                {
                    Console.Write($"{number} ");
                    i++;
                }
                
                number++;
            }
        }
    }
}