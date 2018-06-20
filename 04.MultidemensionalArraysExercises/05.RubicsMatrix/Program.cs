using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace _05.RubicsMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse
                ).ToArray();

            var rows = dimension[0];
            var columns = dimension[1];

            var matrix = new int[rows][];
            int count = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[columns];
                for (int colIndex = 0; colIndex < columns; colIndex++)
                {
                    matrix[rowIndex][colIndex] = count;
                    count++;
                }
            }
            var commandNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandNum; i++)
            {
                var CommandToken = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var rcIndex = int.Parse(CommandToken[0]);
                var direction = CommandToken[1];
                var moves = int.Parse(CommandToken[2]);

                switch (direction)
                {
                    case "up":
                        MoveCol(matrix,rcIndex,moves);
                        break;
                    case "down":
                        MoveCol(matrix,rcIndex,rows-moves % rows);
                        break;
                    case "left":
                        MoveRow(matrix,rcIndex,moves);
                        break;
                    case "right":
                        MoveRow(matrix,rcIndex,columns - moves % columns);
                        break;
                }
            }
            var element = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    var temp = matrix[row][col];
                                    matrix[row][col] = element;
                                    matrix[r][c] = temp;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }
            
        }

        private static void MoveRow(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix[0].Length];
            for (int col = 0; col < matrix[0].Length; col++)
            {
                temp[col] = matrix[rcIndex][(col + moves) % matrix[0].Length];
            }
            matrix[rcIndex] = temp;
        }

        private static void MoveCol(int[][] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[(row + moves) % matrix.Length][rcIndex];
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][rcIndex] = temp[row];
            }
        }
    }
}

