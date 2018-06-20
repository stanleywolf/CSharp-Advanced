using System;
using System.Linq;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] rowValue = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = rowValue[col];
                }
            }
            int sum = 0;
            int bestSum = 0;

            int rowIndex = 0, colIndex = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] +
                          matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            Console.WriteLine(matrix[rowIndex,colIndex]+" "+matrix[rowIndex,colIndex+1]+" "+matrix[rowIndex,colIndex + 2]);
            Console.WriteLine(matrix[rowIndex + 1, colIndex] + " " + matrix[rowIndex + 1, colIndex + 1] + " " + matrix[rowIndex + 1, colIndex + 2]);
            Console.WriteLine(matrix[rowIndex + 2, colIndex] + " " + matrix[rowIndex + 2, colIndex + 1] + " " + matrix[rowIndex + 2, colIndex + 2]);
        }
    }
}
