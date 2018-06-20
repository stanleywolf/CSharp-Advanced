using System;
using System.Collections.Generic;

namespace _01.RevereseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            //var reverse = new Stack<char>(input.ToCharArray());- директно го пълним
            
           // Stack<char> reverse = new Stack<char>(input.Length);-задаваме му дължина

            Stack<char> reverse = new Stack<char>();

            foreach (var character in input)
            {
                reverse.Push(character);
            }
            while (reverse.Count > 0)
            {
                Console.Write(reverse.Pop().ToString());
            }
            Console.WriteLine();
        }
    }
}
