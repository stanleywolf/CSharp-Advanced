using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SiquenceInQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(n);
            List<int> list = new List<int>();
            list.Add(n);
            while (list.Count <= 50)
            {               
                list.Add(queue.Peek() + 1);
                queue.Enqueue(queue.Peek() + 1);

                list.Add(2 * queue.Peek() + 1);
                queue.Enqueue(2 * queue.Peek() + 1);

                list.Add(queue.Peek() + 2);
                queue.Enqueue(queue.Peek() + 2);

                queue.Dequeue();
            }
            Console.WriteLine(string.Join(" ",list.Take(50)));
        }
    }
}
