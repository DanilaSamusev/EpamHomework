﻿using System;

namespace Module3_6
{
    public class ArrayInitializer
    {
        public double[] FillArray()
        {
            int arraySize = GetArraySize();
            double[] array = new double[arraySize];

            for (int i = 0; i < arraySize;)
            {
                Console.Write($"Inter the {i + 1} array number: ");

                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    array[i] = number;
                    i++;
                }
                else
                {
                    Console.WriteLine("Error: array element has to be a number!\n--------------------------------");
                }
            }

            return array;
        }

        private int GetArraySize()
        {
            while (true)
            {
                Console.Write("Inter the array size: ");

                if (int.TryParse(Console.ReadLine(), out int arraySize) && arraySize > 0)
                {
                    return arraySize;
                }
                
                Console.WriteLine("Error: array size has to be a positive integer!\n--------------------------------");
            }
        }
    }
}