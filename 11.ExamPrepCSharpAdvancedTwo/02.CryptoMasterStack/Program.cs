using System;
using System.Linq;

namespace _02.CryptoMasterStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[]{", "},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int maxSiquence = 0;
            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step)% numbers.Length;
                    int currentSiquence = 1;
                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                        currentSiquence++;
                    }
                    if (currentSiquence > maxSiquence)
                    {
                        maxSiquence = currentSiquence;
                    }
                }
            }
            Console.WriteLine(maxSiquence);
        }
    }
}
