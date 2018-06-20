using System;
using System.Linq;
using System.Linq.Expressions;

namespace _01.DangerousFloorMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] chestDesk = new char[8][];

            for (int i = 0; i < chestDesk.Length; i++)
            {
                chestDesk[i] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
            }

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
               
                var figure = command[0];
                var startRow = int.Parse(command[1].ToString());
                var startCol = int.Parse(command[2].ToString());
                var newRow = int.Parse(command[4].ToString());
                var newCol = int.Parse(command[5].ToString());
                if (FigureExist(startRow, startCol, chestDesk, figure))
                {
                    if (IsValidMove(startRow, startCol, newRow, newCol, chestDesk, figure))
                    {
                        if (IsBoard(newRow, newCol,8))
                        {
                            MoveFigure(startRow, startCol, newRow, newCol, chestDesk, figure);
                        }
                        else
                        {
                            Console.WriteLine("Move go out of board!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
               
            }
        }

        private static void MoveFigure(int startRow, int startCol, int newRow, int newCol, char[][] chestDesk, char figure)
        {
            if (chestDesk[newRow][newCol] == 'x')
            {
                chestDesk[startRow][startCol] = 'x';
                chestDesk[newRow][newCol] = figure;
            }
        }

        private static bool IsValidMove(int startRow, int startCol, int newRow, int newCol, char[][] chestDesk, char figure)
        {
            switch (figure)
            {
                case 'K':
                    return ValidKingMove(startRow, startCol, newRow, newCol, chestDesk);
                    break;
                case 'R':
                    return ValidStraightMove(startRow, startCol, newRow, newCol, chestDesk);
                    break;
                case 'B':
                    return ValidDiagonalMove(startRow, startCol, newRow, newCol, chestDesk);
                    break;
                case 'Q':
                    return ValidDiagonalMove(startRow, startCol, newRow, newCol, chestDesk) ||
                           ValidStraightMove(startRow, startCol, newRow, newCol, chestDesk);
                    break;
                case 'P':
                    return ValidPawnMove(startRow, startCol, newRow, newCol, chestDesk);
                    break;
                    default:
                        throw new Exception();
            }
            return true;
        }

        private static bool ValidKingMove(int startRow, int startCol, int newRow, int newCol, char[][] chestDesk)
        {
            bool validRow = Math.Abs(startRow - newRow) == 1 && Math.Abs(startCol - newCol) == 0;
            bool validCol = Math.Abs(startCol - newCol) == 1 && Math.Abs(startRow - newRow) == 0;
            bool diagMove = Math.Abs(startRow - newRow) == 1 && Math.Abs(startCol - newCol) == 1;
            return validRow || validCol || diagMove;
        }

        private static bool ValidDiagonalMove(int startRow, int startCol, int newRow, int newCol, char[][] chestDesk)
        {

            return Math.Abs(startRow - newRow) == Math.Abs(startCol - newCol);
        }

        private static bool ValidStraightMove(int startRow, int startCol, int newRow, int newCol, char[][] chestDesk)
        {
            bool sameRow = startRow == newRow;
            bool sameCol = startCol == newCol;

            return sameCol || sameRow;
        }

        private static bool ValidPawnMove(int startRow, int startCol, int newRow, int newCol, char[][] chestDesk)
        {
            bool validCol = startCol == newCol;
            bool validRow = startRow - 1 == newRow;
            return validRow && validCol;
        }

        private static bool IsBoard(int row, int col, int chestDeskSize)
        {
            return row >= 0 && row < chestDeskSize && col >= 0 && col < chestDeskSize;
        }

        private static bool FigureExist(int row, int col, char[][] chestDesk, char figure)
        {
            return chestDesk[row][col] == figure;
        }
    }
}
