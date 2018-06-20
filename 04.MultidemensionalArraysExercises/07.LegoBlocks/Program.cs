using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = int.Parse(Console.ReadLine());
            var first = new int[dimension][];
            var second = new int[dimension][];

            FillJagged(dimension, first, second);

            int a = first[0].Length;
            int b = second[0].Length;
            int c = a + b;
            bool fitting = true;
            var cellsCount = c;

            for (int index = 1; index < dimension; index++)
            {
                a = first[index].Length;
                b = second[index].Length;
                cellsCount += a + b;

            }

            if (a + b == c)
            {

                for (int i = 0; i < dimension; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", first[i])}, {string.Join(", ", second[i])}]");
                }

            }
            else
            {
                int sum = 0;
                for (int i = 0; i < dimension; i++)
                {
                    sum += first[i].Length + second[i].Length;
                }
                Console.WriteLine($"The total number of cells is: {sum}");
            }
        }

        private static void FillJagged(int dimension, int[][] first, int[][] second)
        {
            for (int rowIndex = 0; rowIndex < dimension; rowIndex++)
            {
                first[rowIndex] = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
            var temp = new int[dimension];
            for (int rowIndex = 0; rowIndex < dimension; rowIndex++)
            {
                temp = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                Array.Reverse(temp);
              // for (int i = 0; i < temp.Length / 2; i++)
              // {
              //     var elem = temp[i];
              //     temp[i] = temp[temp.Length - 1];
              //     temp[temp.Length - 1] = elem;                   
              // }
               second[rowIndex] = temp;
            }
           
            
        }
    }
}
