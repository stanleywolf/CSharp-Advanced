using System;
using System.Linq;

namespace _03.SquareOfMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new Char[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                char[] rowValue = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = rowValue[col];
                }
            }

            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                   
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col + 1] == matrix[row + 1, col] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
