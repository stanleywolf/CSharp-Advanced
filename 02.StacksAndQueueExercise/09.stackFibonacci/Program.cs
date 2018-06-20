using System;
using System.Collections;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());
         //  var stack = new Queue<long>();
         //  stack.Enqueue(0);
         //  stack.Enqueue(1);
         //  long result = 0;
         //  for (int i = 0; i <= number-2; i++)
         //  {
         //      result = 0;
         //      result = stack.Dequeue() + stack.Peek();
         //      stack.Enqueue(result);
         //      
         //  }
         //  Console.WriteLine(result);
         var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            
            for (int i = 2; i <= number; i++)
            {
                var minusOne = stack.Pop();
                var minusTwo = stack.Peek();
                stack.Push(minusOne);

                var fibonacci = minusTwo + minusOne;
                stack.Push(fibonacci);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
