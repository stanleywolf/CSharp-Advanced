using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = size[0];
            var columns = size[1];

            List<List<int>> target = new List<List<int>>();
            int count = 1;
            for (int row = 0; row < rows; row++)
            {
                var rowList = new List<int>();
                for (int col = 0; col < columns; col++)
                {
                    rowList.Add(count);
                    count++;
                }
                target.Add(rowList);
            }
           string command = String.Empty;

            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                var tokens = command.Split().Select(int.Parse).ToArray();

                var rowShot = tokens[0];
                var colShot = tokens[1];
                var redius = tokens[2];

                for (int row = 0; row < target.Count; row++)
                {
                    for (int col = 0; col < target[row].Count; col++)
                    {
                        if ((row == rowShot && Math.Abs(col - colShot) <= redius) ||
                            (col == colShot && Math.Abs(row - rowShot) <= redius))
                        {
                            target[row][col] = 0;
                        }
                    }
                }
                for (int i = 0; i < target.Count; i++)
                {
                    target[i].RemoveAll(x => x == 0);
                    if (target[i].Count == 0)
                    {
                        target.RemoveAt(i);
                        i--;
                    }
                }
               
            }
            for (int res = 0; res < target.Count; res++)
            {
                Console.WriteLine(string.Join(" ", target[res]));
            }
        }
    }
}
