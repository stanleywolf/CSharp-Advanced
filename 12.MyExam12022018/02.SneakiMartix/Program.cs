using System;
using System.Linq;
using System.Numerics;

namespace _02.SneakiMartix
{
      
    class Program
    {
        
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var columns = length * 2;
            char[][] matrix = new char[length][];
            for (int i = 0; i < length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            var samRow = 0;
            var samCol = 0;
            var nikoRow = 0;
            var nikoCol = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    // FindSamAndNico(row, col, matrix,samRow,samCol,nikoRow, nikoCol);
                    if (matrix[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                    else if (matrix[row][col] == 'N')
                    {
                        nikoRow = row;
                        nikoCol = col;
                    }
                }
            }
            
            var command = Console.ReadLine().ToCharArray();
            for (int i = 0; i < command.Length; i++)
            {
                
                for (int row = 0; row < length; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        //first enemyMove
                        //EnemyMoves(length, columns, matrix, samRow, samCol, row, col);
                        if (matrix[row][col] == 'b')
                        {
                            if (!IsBoardEnemy(row, col + 1, matrix, columns))
                            {
                                matrix[row][col] = 'd';
                            }
                            else
                            {
                                matrix[row][col + 1] = 'b';
                                col++;
                            }
                            if (SeeSam(row, col, samRow, samCol, matrix))
                            {
                                matrix[samRow][samCol] = 'X';
                                PrintSamDeath(samRow, samCol, matrix, length);
                                PrintMatrix(matrix, length);
                                return;
                            }
                            matrix[row][col] = '.';
                           

                        }
                        else if (matrix[row][col] == 'd')
                        {
                            if (!IsBoardEnemy(row, col - 1, matrix, columns))
                            {
                                matrix[row][col] = 'b';
                            }
                            else
                            {
                                matrix[row][col - 1] = 'd';

                            }
                            if (SeeSam(row, col, samRow, samCol, matrix))
                            {
                                matrix[samRow][samCol] = 'X';
                                PrintSamDeath(samRow, samCol, matrix, length);
                                PrintMatrix(matrix, length);
                                return;
                            }
                            matrix[row][col] = '.';
                           

                        }
                    }
                }
                
                        //second Sams move
                        switch (command[i])
                        {
                            case 'U':
                                if (IsBoardEnemy(samRow - 1, samCol, matrix, length) || (KillEnemy(matrix, samRow - 1, samCol)))
                                {
                                    matrix[samRow][samCol] = '.';
                                    matrix[samRow - 1][samCol] = 'S';
                                }
                                samRow = samRow - 1;
                                KillNikolaz(samRow, samCol, nikoRow, nikoCol, matrix, length);

                                break;
                            case 'D':
                                if (IsBoardEnemy(samRow + 1, samCol, matrix, length) || (KillEnemy(matrix, samRow + 1, samCol)))
                                {
                                    matrix[samRow][samCol] = '.';

                                    matrix[samRow + 1][samCol] = 'S';
                                }
                                samRow = samRow + 1;
                                KillNikolaz(samRow, samCol, nikoRow, nikoCol, matrix, length);
                                
                                break;
                            case 'L':
                                if (IsBoardEnemy(samRow, samCol - 1, matrix, length) || (KillEnemy(matrix, samRow, samCol - 1)))
                                {
                                    matrix[samRow][samCol] = '.';

                                    matrix[samRow][samCol - 1] = 'S';
                                }
                                samCol = samCol - 1;
                                KillNikolaz(samRow, samCol, nikoRow, nikoCol, matrix, length);
                                break;
                            case 'R':
                                if (IsBoardEnemy(samRow, samCol + 1, matrix, length) || (KillEnemy(matrix, samRow, samCol + 1)))
                                {
                                    matrix[samRow][samCol] = '.';

                                    matrix[samRow][samCol + 1] = 'S';
                                }
                                samCol = samCol + 1;
                                KillNikolaz(samRow, samCol, nikoRow, nikoCol, matrix, length);
                                
                                break;
                            case 'W':
                                break;
                        }
                    }       
                }
            
        

        private static void KillNikolaz(int samRow, int samCol, int nikoRow, int nikoCol, char[][] matrix , int length)
        {
            if (samRow == nikoRow)
            {
                matrix[nikoRow][nikoCol] = 'X';
                matrix[samRow][samCol] = '.';
                Console.WriteLine("Nikoladze killed!");
                PrintMatrix(matrix,length);
                return;
            }
        }

        private static bool KillEnemy(char[][] matrix, int samRow, int samCol)
        {
            if (matrix[samRow][samCol] == 'd' || matrix[samRow][samCol] == 'b')
            {
               return true;
            }
            else
            {
                return false;
            }
        }

        private static void EnemyMoves(int length, int columns, char[][] matrix, int samRow, int samCol, int row, int col)
        {
           
        }

        private static void PrintMatrix(char[][] matrix, int length)
        {
            for (int rows = 0; rows < length; rows++)
            {
                Console.WriteLine(string.Join("", matrix[rows]));
            }
            return;
        }

        private static void PrintSamDeath(int samRow, int samCol, char[][] matrix, int length)
        {
            Console.WriteLine($"Sam died at {samRow}, {samCol}");          
        }

        private static bool SeeSam(int row, int col, int samRow, int samCol, char[][] matrix)
        {
            if (matrix[row][col] == 'b')
            {
            return row == samRow && col < samCol;
            }           
            else if(matrix[row][col] == 'd')
            {
                return row == samRow && col > samCol;
            }
            else
            {
                return false;
            }
        }

        

        private static bool IsBoardEnemy(int row, int col, char[][] matrix, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length * 2;
        }
    }
}
