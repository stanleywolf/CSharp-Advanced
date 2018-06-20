using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.RegehRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\[[a-zA-Z]+<(\d+)REGEH(\d+)>[a-zA_Z]+\]";
           // var regex = @"\[[A-Z&a-z]+<([0-9]+)REGEH([0-9]+)>[A-Z&a-z]+\]";
            var text = Console.ReadLine().Trim();
            MatchCollection matches = Regex.Matches(text, regex);
            var result = new StringBuilder();
            var firstNum = 0;
            var secNum = 0;
            var queue = new List<int>();
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        firstNum = int.Parse(match.Groups[1].Value);
                        queue.Add(firstNum);
                        secNum = int.Parse(match.Groups[2].Value);
                        queue.Add(secNum);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }
            int next = queue[0];
            var first = text[queue[0] % text.Length];
            result.Append(first);
            for (int i = 1; i < queue.Count; i++)
            {
                next += queue[i];
                result.Append(text[next % text.Length]);

            }
           
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
