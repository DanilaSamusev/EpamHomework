﻿using System;

namespace Module3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber();
            PrintFibonacci(number);
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
                
                Console.WriteLine("Error: input data has to be a positive integer\n-------------------------");
            }
        }

        static void PrintFibonacci(int numbersCount)
        {
            int temp1 = 0;
            int temp2 = 1;
            
            Console.Write($"Result: {temp1}");
            
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