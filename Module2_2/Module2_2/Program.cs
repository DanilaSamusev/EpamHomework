using System;

namespace Module2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = GetAge();

            if (age % 2 == 0 && age > 18)
            {
                Console.WriteLine("Happy birthday! You have reached 18!");
            }

            if (age % 2 != 0 && age > 13 && age < 18)
            {
                Console.WriteLine("Congratulations on moving to high school!");
            }
        } 
        
        static int GetAge()
        {
            while (true)
            {
                Console.Write("Inter your age: ");
                bool isAgeParsed = int.TryParse(Console.ReadLine(), out int age);

                if (!isAgeParsed)
                {
                    Console.WriteLine("Error: the age has to be!\n------------------------------");
                }

                return age;
            }
        }
    }
}