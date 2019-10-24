using System;

namespace Module4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringParser = new DataParser();
            double number1 = stringParser.ParseToDouble("first number");
            double number2 = stringParser.ParseToDouble("second number");
            Operation operation = stringParser.GetEnum();
            double result = Count(number1, number2, operation);
            Console.WriteLine($"Result is {result}");
            
            int monthNumber = stringParser.GetInt();
            int daysInMonth = CountDaysInMonth(monthNumber);
            Console.WriteLine($"Days: {daysInMonth}");
        }
        private static double Count(double number1, double number2, Operation operation)
        {
            var result = operation switch
            {
                Operation.Plus => (number1 + number2),
                Operation.Minus => (number1 - number2),
                Operation.Multiply => (number1 * number2),
                Operation.Divide => (number1 / number2),
                _ => 0
            };

            return result;
        }

        private static int CountDaysInMonth(int month)
        {
            return DateTime.DaysInMonth(2019, month);
        }
    }
}