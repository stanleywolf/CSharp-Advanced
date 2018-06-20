using System;
using System.Linq;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var sizes = new int[3];
            foreach (var number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }
            int[][] jagged = new int[3][];

            for (int counter = 0; counter < sizes.Length; counter++)
            {
            jagged[counter] = new int[sizes[counter]];    
            }

            int[] index = new int[3];
            foreach (var number in numbers)
            {
                var reminder = number % 3;
                jagged[reminder][index[reminder]] = number;
                index[reminder]++;
            }
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
