using System;
using System.Linq;

namespace _07.PredicateByNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var lenght = int.Parse(Console.ReadLine());

            Func<string, bool> filter = x => x.Length <= lenght;
            var names = Console.ReadLine().Split()
                .Where(filter).ToArray();
            Console.WriteLine(string.Join("\n",names));
        }
    }
}
