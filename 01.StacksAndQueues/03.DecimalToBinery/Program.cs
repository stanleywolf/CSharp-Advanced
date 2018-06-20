using System;
using System.Collections.Generic;

namespace _03.DecimalToBinery
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            if (input == 0)
            {
                Console.WriteLine(0);
                return;
            }
            while (input > 0)
            {
                stack.Push(input % 2);
                input /= 2;
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
