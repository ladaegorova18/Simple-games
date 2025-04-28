using System;
using static System.Math;

namespace First100Shinuses
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            Console.WriteLine("Enter count of shinuses:");
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; ++i)
            {
                sum += Shinus(i, n);
            }
            Console.WriteLine(sum);
        }

        private static double Shinus(int k, int n)
        {
            return Sinh((k + Sqrt(k)) / (n * n));
        }
    }
}
