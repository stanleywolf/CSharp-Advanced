using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvansOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var start = numbers[0];
            var end = numbers[1];

            var command = Console.ReadLine();
            Predicate<int> predicate;
            switch (command)
            {
                case "odd":
                    predicate = n => n % 2 != 0;
                    break;
                case "even":
                    predicate = n => n % 2 == 0;
                    break;
                default:
                    predicate = null;
                    break;
            }
            var result = EvenOrOdd(start, end, predicate);
            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> EvenOrOdd(int start, int end, Predicate<int> predicate)
        {
            var result = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
