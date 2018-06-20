using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            var numOfPush = input[0];
            var countOfPop = input[1];
            var chechedNumber = input[2];
           
            var nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(nums);
            for (int i = 0; i < countOfPop; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (stack.Contains(chechedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
