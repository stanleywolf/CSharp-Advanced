using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = s => char.IsUpper(s[0]);
           var words = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                //.Where(s => s[0].ToString() == s[0].ToString().ToUpper()) //.Where(s => char.IsUpper(s[0]))
                .ToList();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
