using System;

namespace Module1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            
            Console.WriteLine("a: " + a + " b: " + b);
            Swap(ref a, ref b);
            Console.WriteLine("a: " + a + " b: " + b);
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}