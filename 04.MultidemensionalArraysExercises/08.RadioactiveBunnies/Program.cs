using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _08.RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[matrixData[0], matrixData[1]];

            int[] playerPosition = new int[2];

            FillMatrix(matrix, playerPosition);

            string cmds = Console.ReadLine();

            for (int i = 0; i < cmds.Length; i++)
            {
                MovePlayer(cmds[i], playerPosition);

                bool isWin = IsGameWon(matrix, playerPosition);

                char[,] mutatedMatrix = MutateBunnies(matrix);
                matrix = mutatedMatrix;

                if (isWin)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
                    Environment.Exit(0);
                }

                IsGameOver(matrix, playerPosition);
            }

            matrix[playerPosition[0], playerPosition[1]] = 'P';
            PrintMatrix(matrix);
            Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
        }

        private static bool IsGameWon(char[,] matrix, int[] playerPosition)
        {
            bool isGameWon = false;

            if (playerPosition[0] >= matrix.GetLength(0) || playerPosition[0] < 0 ||
                    playerPosition[1] < 0 || playerPosition[1] >= matrix.GetLength(1))
            {
                isGameWon = true;
                if (playerPosition[0] >= matrix.GetLength(0)) playerPosition[0] = matrix.GetLength(0) - 1;
                else if (playerPosition[0] < 0) playerPosition[0] = 0;
                else if (playerPosition[1] >= matrix.GetLength(1)) playerPosition[1] = matrix.GetLength(1) - 1;
                else if (playerPosition[1] < 0) playerPosition[1] = 0;
            }

            return isGameWon;
        }

        private static void IsGameOver(char[,] matrix, int[] playerPosition)
        {

            if (matrix[playerPosition[0], playerPosition[1]] == 'B')
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
                Environment.Exit(0);
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] MutateBunnies(char[,] matrix)
        {
            int topBorder = 0, bottomBorder = matrix.GetLength(0),
                leftBorder = 0, rightBorder = matrix.GetLength(1);

            char[,] mutatedMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];

            FillBlankMutatedMatrix(mutatedMatrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        mutatedMatrix[i, j] = 'B';

                        if ((j + 1) < rightBorder && matrix[i, j + 1] == '.')
                        {
                            mutatedMatrix[i, j + 1] = 'B';
                        }
                        if ((j - 1) >= leftBorder && matrix[i, j - 1] == '.')
                        {
                            mutatedMatrix[i, j - 1] = 'B';
                        }
                        if ((i + 1) < bottomBorder && matrix[i + 1, j] == '.')
                        {
                            mutatedMatrix[i + 1, j] = 'B';
                        }
                        if ((i - 1) >= topBorder && matrix[i - 1, j] == '.')
                        {
                            mutatedMatrix[i - 1, j] = 'B';
                        }
                    }
                }
            }

            return mutatedMatrix;
        }

        private static void FillBlankMutatedMatrix(char[,] mutatedMatrix)
        {
            for (int i = 0; i < mutatedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < mutatedMatrix.GetLength(1); j++)
                {
                    mutatedMatrix[i, j] = '.';
                }
            }
        }

        private static void MovePlayer(char cmd, int[] playerPosition)
        {
            switch (cmd)
            {
                case 'R': playerPosition[1] += 1; break;
                case 'L': playerPosition[1] -= 1; break;
                case 'U': playerPosition[0] -= 1; break;
                case 'D': playerPosition[0] += 1; break;
            }
        }

        private static void FillMatrix(char[,] matrix, int[] playerStart)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();

                if (input.Contains('P'))
                {
                    playerStart[0] = i;
                    playerStart[1] = input.IndexOf('P');
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            matrix[playerStart[0], playerStart[1]] = '.';
        }
    }    
}
