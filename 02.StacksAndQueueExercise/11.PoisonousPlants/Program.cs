using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] deathDays = new int[n];
            int[] minElement = new int[n];

            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (plants[i] < min)
                {
                    min = plants[i];
                }
                minElement[i] = min;
            }

            int max = 0;
            int maxIndex = 0;

            for (int i = 1; i < n; i++)
            {
                if (plants[i] > plants[i - 1])
                {
                    deathDays[i] = 1;
                    if (deathDays[i] >= max)
                    {
                        maxIndex = i;
                        max = deathDays[i];
                    }
                    continue;
                }

                if (plants[i] > minElement[i])
                {
                    if (plants[i] > plants[maxIndex])
                    {
                        deathDays[i] = deathDays[i - 1] + 1;
                    }
                    else
                    {
                        deathDays[i] = deathDays[maxIndex] + 1;
                    }
                }
                if (plants[i] == minElement[i])
                {
                    max = 0;
                }

                if (deathDays[i] >= max)
                {
                    maxIndex = i;
                    max = deathDays[i];
                }
            }

            Console.WriteLine(deathDays.Max());
        }

     //  void Short()
     //  {
     //      int n = int.Parse(Console.ReadLine());
     //      int[] plants = Console.ReadLine().Split//().Select(int.Parse).ToArray();
     //
     //      int[] days = new int[plants.Length];
     //      Stack<int> proximityStack = new Stack<int>();
     //      proximityStack.Push(0);
     //
     //      for (int i = 1; i < plants.Length; i++)
     //      {
     //          int maxDays = 0;
     //
     //          while (proximityStack.Count > 0 && plants//[proximityStack.Peek()] >= plants[i])
     //          {
     //              maxDays = Math.Max(maxDays, days//[proximityStack.Pop()]);
     //          }
     //          if (proximityStack.Count > 0)
     //          {
     //              days[i] = maxDays + 1;
     //          }
     //          proximityStack.Push(i);
     //      }
     //      Console.WriteLine(days.Max());
     //  }
    }
    
}



