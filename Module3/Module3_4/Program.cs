using System;

namespace Module3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber();
            int reversedNumber = GetReverseNumber(number);
            Console.WriteLine($"Reversed number: {reversedNumber}");
        }
        
        static int GetNumber()
        {
            while (true)
            {
                Console.Write("Enter the number: ");

                if (int.TryParse(Console.ReadLine(), out int parsedNumber))
                {
                    return parsedNumber;
                }
                
                Console.WriteLine("Error: input data has to be an integer!\n-------------------------");
            }
        }

        static int GetReverseNumber(int number)
        {
            string strNumber = number.ToString();

            if (number < 0)
            {
                strNumber = strNumber.Remove(0, 1);
            }
            
            char[] numberArray = strNumber.ToCharArray();
            Array.Reverse(numberArray);
            string reversedStrNumber = string.Concat(numberArray);

            return int.Parse(number < 0 ? $"-{reversedStrNumber}" : reversedStrNumber);
        }
    }
}