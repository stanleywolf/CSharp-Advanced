using System;
using System.Linq;

namespace _11.ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int columns = int.Parse(input[1]);
            byte[][] matrix = new byte[rows][];             // define array with empty arrays 
                                                            // 0 for empty, 1 for occupied
            string command = "";
            while ((command = Console.ReadLine()) != "stop")
            {
                string[] data = command.Split();
                int entrance = int.Parse(data[0]);
                int rowPark = int.Parse(data[1]);
                int colPark = int.Parse(data[2]);

                int steps = Math.Abs(entrance - rowPark) + 1;   // initial steps in first (0) column
                if (matrix[rowPark] == null)                    // if current array is empty
                {
                    matrix[rowPark] = new byte[columns];        // add new byte array filled with 0
                }

                if (matrix[rowPark][colPark] == 0)
                {
                    matrix[rowPark][colPark] = 1;
                    steps += colPark;                           // add steps in the row to the initial steps
                    Console.WriteLine(steps);
                }
                else
                {
                    int cnt = 1;                            // counter for cells
                    while (true)
                    {
                        int lowerCell = colPark - cnt;
                        int upperCell = colPark + cnt;

                        if (lowerCell < 1 && upperCell > columns - 1)  // if cells are out of bounds
                        {
                            Console.WriteLine($"Row {rowPark} full");
                            break;
                        }
                        if (lowerCell > 0 && matrix[rowPark][lowerCell] == 0)       // if cell is inside of the row
                        {                                                       // and free
                            matrix[rowPark][lowerCell] = 1;
                            steps += lowerCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        if (upperCell < columns && matrix[rowPark][upperCell] == 0) // if cell is inside of the row
                        {                                                        // and is free
                            matrix[rowPark][upperCell] = 1;
                            steps += upperCell;
                            Console.WriteLine(steps);
                            break;
                        }
                        cnt++;
                    }
                }
            }
        }
    }
    
}
