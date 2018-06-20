using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightGamesMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = int.Parse(Console.ReadLine());
            if (boardSize < 3)
            {
                Console.WriteLine(0);
                return;
            }
            var board = new Char[boardSize][];

            FillMatrix(board,boardSize);

            int maxAttackedPos = 0;
            int maxRow = 0;
            int maxCol = 0;
            int countRemKnight = 0;
            do
            {
                if (maxAttackedPos > 0)
                {
                    board[maxRow][maxCol] = '0';
                    maxAttackedPos = 0;
                    countRemKnight++;
                }

                int currentAttackedPos = 0;
                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            currentAttackedPos = CalculateAttackedPosition(row, col, board);
                            if (currentAttackedPos > maxAttackedPos)
                            {
                                maxAttackedPos = currentAttackedPos;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
            }
            while (maxAttackedPos > 0);
            Console.WriteLine(countRemKnight);
        }       

        private static void FillMatrix(char[][] board,int boardSize)
        {
            for (int i = 0; i < boardSize; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }
        }

        private static int CalculateAttackedPosition(int row, int col, char[][] board)
        {
            var currentAttackedPos = 0;
            if (IsPositionAttacked(row - 2, col - 1, board)) currentAttackedPos++;
            if (IsPositionAttacked(row - 2, col + 1, board)) currentAttackedPos++;
            if (IsPositionAttacked(row + 2, col - 1, board)) currentAttackedPos++;
            if (IsPositionAttacked(row + 2, col + 1, board)) currentAttackedPos++;
            if (IsPositionAttacked(row - 1, col - 2, board)) currentAttackedPos++;
            if (IsPositionAttacked(row - 1, col + 2, board)) currentAttackedPos++;
            if (IsPositionAttacked(row + 1, col - 2, board)) currentAttackedPos++;
            if (IsPositionAttacked(row + 1, col + 2, board)) currentAttackedPos++;
            return currentAttackedPos;
        }

        private static bool IsPositionAttacked(int row, int col, char[][] board)
        {
            return IsBoard(row, col, board[0].Length) && board[row][col] == 'K';           
        }
        private static bool IsBoard(int row, int col ,int boardSize)
        {
            return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
        }
    }
}
