using System;
using System.Runtime.CompilerServices;

namespace _04.PascalTringle
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = long.Parse(Console.ReadLine());

            long currentWidht = 1;
            long[][] triangle = new long[height][];

            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                triangle[currentHeight] = new long[currentWidht];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentWidht - 1] = 1;

                if (currentHeight >= 2)
                {
                    for (int widthCounter = 1; widthCounter < currentWidht - 1; widthCounter++)
                    {
                        triangle[currentHeight][widthCounter] =
                            triangle[currentHeight - 1][widthCounter - 1] + triangle[currentHeight - 1][widthCounter];
                    }
                }
                currentWidht++;

            }
            for (int i = 0; i < triangle.Length; i++)
            {
                var row = triangle[i];
                for (int j = 0; j < row.Length; j++)
                {
                    Console.Write(row[j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
