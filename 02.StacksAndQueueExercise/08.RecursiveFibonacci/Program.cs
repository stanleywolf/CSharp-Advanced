using System;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        private static long[] memo;
        static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());
            memo = new long[number +1];               
            Console.WriteLine(GetFibonacci(number));
        }

        private static long GetFibonacci(long number)
        {
            if (number <= 2)
            {
                return 1;
            }
            if (memo[number] == 0)
            {
                memo[number] = GetFibonacci(number - 1) + GetFibonacci(number - 2);
            }
            return memo[number];
        }
    }
}
