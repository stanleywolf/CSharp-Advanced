using System;
using System.IO;

namespace _02.WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var readStream = new StreamReader("Program.cs"))
            {
                using (var writeStream = new StreamWriter("reversed.txt"))
                {
                    string line;
                    while ((line = readStream.ReadLine()) != null)
                    {
                        for (int counter = line.Length - 1; counter >= 0; counter--)
                        {
                            writeStream.Write(line[counter]);
                        }
                        writeStream.WriteLine();
                    }
                }
            }
        }
    }
}
