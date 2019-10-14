using System;

namespace Module2_1
{
    class Program
    {
        private const string CompaniesQuery = "number of companies: ";
        private const string TaxQuery = "tax per company: ";
        private const string CompanyProfit = "company profit: ";

        static void Main(string[] args)
        {
            double companyProfit = GetDoubleData(CompanyProfit);
            int companiesCount = GetIntegerData(CompaniesQuery);
            float taxPerCompany = GetDoubleData(TaxQuery);
            double totalCompaniesTax = CountTotalCompaniesTax(companiesCount, taxPerCompany, companyProfit);
            Console.WriteLine($"Total tax: {totalCompaniesTax}");
        }

        static int GetIntegerData(string query)
        {
            while (true)
            {
                Console.Write($"Inter the {query}");
                bool isDataParsed = int.TryParse(Console.ReadLine(), out int companiesCount);

                if (isDataParsed && companiesCount >= 0)
                {
                    return companiesCount;
                }

                Console.WriteLine("Error: input data has to be a positive integer!\n-----------------------------");
            }
        }

        static float GetDoubleData(string query)
        {
            while (true)
            {
                Console.Write($"Inter the {query}");
                bool isDataParsed = float.TryParse(Console.ReadLine(), out float data);

                if (isDataParsed && data >= 0 && data <= 100)
                {
                    return data;
                }

                Console.WriteLine("Error: input data has to be a positive number!\n-----------------------------");
            }
        }

        static double CountTotalCompaniesTax(int companiesCount, double taxPerCompany, double companyProfit)
        {
            double percentCoefficient = 0.01;

            double totalTax = companiesCount * companyProfit * percentCoefficient * taxPerCompany;

            return totalTax;
        }
    }
}