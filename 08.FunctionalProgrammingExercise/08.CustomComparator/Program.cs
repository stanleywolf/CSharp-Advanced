using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToList();
            Func<int, bool> evenFilter = x => x % 2 == 0;
            var even = new List<int>();
            var odd = new List<int>();
            OddEvenPull(nums, evenFilter, even, odd);
            nums = ConcatArrays(even, odd);
            Console.WriteLine(string.Join(" ", nums));
        }

        private static List<int> ConcatArrays(List<int> even, List<int> odd)
        {
            List<int> nums = even.OrderBy(x => x).Concat(odd.OrderBy(x => x)).ToList();
            
            return nums;
        }

        private static void OddEvenPull(List<int> nums, Func<int, bool> evenFilter, List<int> even, List<int> odd)
        {
            foreach (var num in nums)
            {
                if (evenFilter(num))
                {
                    even.Add(num);
                }
                else
                {
                    odd.Add(num);
                }
            }
        }
    }
}
