using System;

namespace Module4_8
{
    class Program
    {
        static void Main(string[] args)
        {
            double leftBound = GetData("First bound: ");
            double rightBound = GetData("Second bound: ");
            double accuracy = GetData("e: ");
            double solution = FindSolution(leftBound, rightBound, accuracy);
            Console.WriteLine($"Solution: x = {solution}");
        }

        static double GetData(string query)
        {
            while (true)
            {
                Console.Write($"Enter the {query}");

                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    return number;
                }

                Console.WriteLine("Error: input data has to be a number!\n----------------------------------");
            }
        }

        static double FindSolution(double leftBound, double rightBound, double accuracy)
        {
            double solution = (leftBound + rightBound) / 2;

            if (GetFunctionSolution(leftBound) * GetFunctionSolution(solution) < 0)
            {
                rightBound = solution;
            }

            if (GetFunctionSolution(rightBound) * GetFunctionSolution(solution) < 0)
            {
                leftBound = solution;
            }

            if (Math.Abs(rightBound - leftBound) < accuracy)
            {
                return (leftBound + rightBound) / 2;
            }

            return FindSolution(leftBound, rightBound, accuracy);
        }

        static double GetFunctionSolution(double x)
        {
            return 4 * Math.Pow(x, 3) + 4 * x + 1;
        }
    }
}