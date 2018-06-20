using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> filter = x => Console.WriteLine($"Sir {x}");
            Console.ReadLine().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(filter);
        }
    }
}
