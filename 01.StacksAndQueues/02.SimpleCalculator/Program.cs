using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var elements = input.Split(' ');
            var stack = new Stack<string>();
            for (var i = elements.Length - 1; i >= 0; i--)
            {
                stack.Push(elements[i]);
            }
          
            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());
                switch (operation)
                {
                    case "+":
                        stack.Push((leftOperand + rightOperand).ToString());
                        break;
                    case "-":
                        stack.Push((leftOperand - rightOperand).ToString());
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
