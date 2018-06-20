using System;
using System.Linq;

namespace _01.SortEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[]{", "},StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .Where(n => n % 2 == 0)
                .OrderBy(n => n);
            Console.WriteLine(string.Join(", ",numbers));

           
        }
    }
}

    
           
    
