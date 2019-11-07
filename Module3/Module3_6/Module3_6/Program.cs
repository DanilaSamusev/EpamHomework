﻿using System;

namespace Module3_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayInitializer = new ArrayInitializer();
            double[] array = arrayInitializer.FillArray();
            PrintArray(array, "Your");
            ChangeArray(array);
            PrintArray(array, "Reformed");
        }
        
        static void ChangeArray(double[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] *= -1;
            }
        }

        static void PrintArray(double[] array, string message)
        {
            Console.Write($"{message} array is:");

            foreach (var number in array)
            {
                Console.Write($" {number}");
            }
            
            Console.WriteLine();
        }
    }
}