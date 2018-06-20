using System;
using System.Linq;

namespace _01.Actionpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> filter = x => Console.WriteLine(x);
            Console.ReadLine().Split(' ')
                .ToList()
                .ForEach(filter);
        }
    }
}
