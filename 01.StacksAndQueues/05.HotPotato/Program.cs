using System;
using System.Collections;
using System.Collections.Generic;

namespace _05.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split(' ');
            var counter = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(children);
            while (queue.Count != 1)
            {
                for (int i = 1; i < counter; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                    //Слагаме в края на опашката първия от опашката.                   
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
