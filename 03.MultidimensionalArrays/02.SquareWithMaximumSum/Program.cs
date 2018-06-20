using System;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColumns = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[,] matrix = new int[rowsAndColumns[0],rowsAndColumns[1]];

            for (int row = 0; row < rowsAndColumns[0]; row++)
            {
                var rowValues = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < rowsAndColumns[1]; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
            int sum = 0;
            int rowIndex = 0, colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var tempSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] +
                                  matrix[row + 1, col + 1];
                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            Console.WriteLine(matrix[rowIndex,colIndex] + " " + matrix[rowIndex,colIndex + 1]);
            Console.WriteLine(matrix[rowIndex + 1, colIndex] + " " + matrix[rowIndex + 1, colIndex + 1]);
            Console.WriteLine(sum);
        }
    }
}
