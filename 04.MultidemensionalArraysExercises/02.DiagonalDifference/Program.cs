using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size,size];

            for (int row = 0; row < size; row++)
            {
                var rowValue = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowValue[col];
                }
            }
            int primariSum = 0;
            int secondariSum = 0;
            int rows = 0;
            int columns = 0;
           
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    primariSum += matrix[rows++, columns++];                    
                }
            
            int rowsSec = 0;
            int colSec = matrix.GetLength(1) - 1;
            
                for (int col = 0; col < matrix.GetLength(1); col++)
                {                    
                    secondariSum += matrix[rowsSec++,colSec--];
                }
            
            Console.WriteLine(Math.Abs(primariSum-secondariSum));
        }
    }
}
