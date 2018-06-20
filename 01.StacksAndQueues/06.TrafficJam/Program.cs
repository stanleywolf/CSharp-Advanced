using System;
using System.Collections.Generic;

namespace _06.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfGreenLights = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();

            var input = String.Empty;
            var totalCars = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    var carsCanPass = Math.Min(queue.Count, countOfGreenLights);
                    for (int i = 0; i < carsCanPass; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        totalCars += 1;
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{totalCars} cars passed the crossroads.");
        }
    }
}
