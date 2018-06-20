using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.PlantsTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantsNumber = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var deathDays = new int[plantsNumber];
            var previousPlants = new Stack<int>();

            previousPlants.Push(0);

            for (int i = 1; i < plantsNumber; i++)
            {
                int lastDayDeath = 0;

                while (previousPlants.Count > 0 && plants[previousPlants.Peek()] >= plants[i])
                {
                    lastDayDeath = Math.Max(lastDayDeath, deathDays[previousPlants.Pop()]);
                    deathDays[i] = lastDayDeath + 1;
                }
                
                previousPlants.Push(i);                
            }
            Console.WriteLine(deathDays.Max());
        }
    }
}
