using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var endIndex = int.Parse(Console.ReadLine());
            var numbers = new List<int>();
            numbers = PrepereResult(endIndex, numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> PrepereResult(int endIndex, List<int> numbers)
        {
            for (int i = 1; i <= endIndex; i++)
            {
                numbers.Add(i);
            }
            var dividers = Console.ReadLine().Split()
                .Select(int.Parse)
                .Distinct()
                .ToArray();
            for (int i = 0; i < dividers.Length; i++)
            {
                Func<int, bool> divideFilter = x => x % dividers[i] == 0;
                numbers = numbers.Where(divideFilter).ToList();
            }

            return numbers;
        }
    }
}
