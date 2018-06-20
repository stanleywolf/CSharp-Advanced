using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stackOpenBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stackOpenBrackets.Push(i);
                }
                if (input[i] == ')')
                {
                    var openBracketIndex = stackOpenBrackets.Pop();
                    var lenght = i - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex,lenght));
                }
            }
        }
    }
}
