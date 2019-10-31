using System;

namespace Module4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 5;
            int secondNumber = 2;
            int thirdNumber = 3;
            double firstDouble = 5.4;
            double secondDouble = 3.1;
            double thirdDouble = 2.9;
            string firstString = "I love ";
            string secondString = "C#";
            double[] firstArray = {1, 2, 3, 5.4};
            double[] secondArray = {5, 2, 1.1 };
            Console.WriteLine($"{firstNumber} + {secondNumber} = {SumUp(firstNumber, secondNumber)}");
            Console.WriteLine($"{firstNumber} + {secondNumber} + {thirdNumber} =" +
                              $" {SumUp(firstNumber, secondNumber, thirdNumber)}");
            Console.WriteLine($"{firstDouble} + {secondDouble} + {thirdDouble} =" +
                              $" {SumUp(firstDouble, secondDouble, thirdDouble)}");
            Console.WriteLine($"{firstString} + {secondString} = {SumUp(firstString, secondString)}");
            double[] resultArray = SumUp(firstArray, secondArray);
            Console.WriteLine($"({GetArrayAsString(firstArray)}) + ({GetArrayAsString(secondArray)}) = " +
                              $"({GetArrayAsString(resultArray)})");
        }    

        static int SumUp(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        
        static int SumUp(int firstNumber, int secondNumber, int thirdNumber)
        {
            return firstNumber + secondNumber + thirdNumber;
        }

        static double SumUp(double firstNumber, double secondNumber, double thirdNumber)
        {
            return firstNumber + secondNumber + thirdNumber;
        }

        static string SumUp(string firstString, string secondString)
        {
            return firstString + secondString;
        }

        static double[] SumUp(double[] firstArray, double[] secondArray)
        {
            double[] smallArray;
            double[] bigArray;

            if (firstArray.Length >= secondArray.Length)
            {
                bigArray = firstArray;
                smallArray = secondArray;
            }
            else
            {
                bigArray = secondArray;
                smallArray = firstArray;
            }

            var summedArray = new double[bigArray.Length];
            Array.Copy(bigArray, summedArray, bigArray.Length);
            
            for (var i = 0; i < smallArray.Length; i++)
            {
                summedArray[i] += smallArray[i];
            }

            return summedArray;
        }

        static string GetArrayAsString(double[] array)
        {
            var arrayString = string.Empty;
            
            foreach (var number in array)
            {
                arrayString += (number);
            }

            return arrayString;
        }
    }
}