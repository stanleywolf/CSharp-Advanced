using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);//излизаме от метода
            }
            char[] openning = new[] {'(', '{', '['};
            char[] closing = ")}]".ToCharArray();

            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (openning.Contains(element))
                {
                    stack.Push(element);
                }
                else if (closing.Contains(element))
                {
                    var lastElement = stack.Pop();
                    if (Array.IndexOf(openning, lastElement) != Array.IndexOf(closing, element))
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }
            if (stack.Any())
            {
                Console.WriteLine("NO");               
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
