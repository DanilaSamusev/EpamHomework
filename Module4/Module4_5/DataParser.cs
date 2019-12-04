using System;

namespace Module4_5
{
    public class DataParser
    {
        public double ParseToDouble(string query)
        {
            while (true)
            {
                Console.Write($"Inter the {query}: ");
                
                if (double.TryParse(Console.ReadLine(), out double parsedNumber))
                {
                    return parsedNumber;
                }

                Console.WriteLine("Error: input data has to be a decimal\n---------------------------");
            }
        }
        
        public Operation GetEnum()
        {
            while (true)
            {
                Console.Write("Inter Plus, Minus, Divide or Multiply: ");
                
                if (Enum.TryParse(Console.ReadLine(), out Operation parsedOperation))
                {
                    return parsedOperation;
                }
                
                Console.WriteLine("Error: check input data!\n---------------------------");
            } 
        }

        public int GetInt()
        {
            while (true)
            {
                Console.Write("Inter the month number: ");

                if (int.TryParse(Console.ReadLine(), out int parsedNumber))
                {
                    return parsedNumber;
                }
                
                Console.WriteLine("Error: input data has to be a digit between 1 and 12\n---------------------------");
            } 
        }
    }
}