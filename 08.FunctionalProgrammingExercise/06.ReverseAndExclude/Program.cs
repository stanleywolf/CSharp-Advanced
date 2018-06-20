using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split()
                .Select(int.Parse)
                .Reverse().ToList();
            var divider = int.Parse(Console.ReadLine());

            Func<int,bool> predicate = x => x % divider != 0;
            var result = nums.Where(predicate);
            //Predicate<int> predicate = x => x % divider != 0;
             //var result = new List<int>();
             //foreach (var num in nums)
             //{
             //    if(predicate(num))
             //        result.Add(num);
             //}
             Console.WriteLine(string.Join(" ",result));
        }
    }
}
