using System;

namespace Module3_8
{
    class Program
    {
        static void Main(string[] args)
        {
            double leftBound = GetFunctionData("left bound: ");
            double rightBound = GetFunctionData("right bound: ");
            double accuracy = GetFunctionData("accuracy: ");
            double solution = FindSolution(leftBound, rightBound, accuracy);
            Console.WriteLine($"Solution: x = {solution}");
            
            int matrixSize = GetMatrixData();
            var matrix = new int[matrixSize, matrixSize];
            var matrixFiller =  new MatrixFiller();
            matrixFiller.FillMatrixInSpiral(matrix);
            DisplayMatrix(matrix);
        }

        static double GetFunctionData(string query)
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
            while (Math.Abs(rightBound - leftBound) > accuracy)
            {
                double solution = (leftBound + rightBound) / 2;
                
                if (Function(leftBound) * Function(solution) < 0)
                {
                    rightBound = solution;
                }
                
                if (Function(rightBound) * Function(solution) < 0)
                {
                    leftBound = solution;
                }
            }
            
            return (leftBound + rightBound) / 2;
        }
        static double Function(double x)
        {
            return 4 * Math.Pow(x, 3) + 4 * x + 1;
        }
        
        static int GetMatrixData()
        {
            while (true)
            {
                Console.Write("Inter the matrix size: ");

                if (int.TryParse(Console.ReadLine(), out int parsedNumber) && parsedNumber > 0)
                {
                    return parsedNumber;
                }
                
                Console.WriteLine("Error: input data has to be a positive integer\n---------------------------------!");
            }
        }

        static void DisplayMatrix(int[,] matrix)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                for (var i = 0; i < matrix.GetLength(1); i++)
                {
                    Console.Write($"{matrix[j,i]}\t");
                }
                
                Console.WriteLine();
            }
        }
    }
}