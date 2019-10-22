using System;

namespace Module2_4
{
    public class DataParser
    {
        public static double GetDouble(string query)
        {
            while (true)
            {
                Console.Write($"Inter the {query}");
                bool isNumberParsed = double.TryParse(Console.ReadLine(), out double parsedNumber);

                if (isNumberParsed)
                {
                    return parsedNumber;
                }

                Console.WriteLine("Error: input data has to be a decimal\n---------------------------");
            }
        }
    }
}