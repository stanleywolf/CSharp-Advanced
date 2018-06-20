using System;
using System.IO;
using System.Net.Http;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var file = "../Resourse/text.txt";
            using (var reader = new StreamReader(file))
            {               
                    var lineNumber = 0;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineNumber % 2 == 1)
                        {
                            Console.WriteLine(line);
                        }
                        lineNumber++;
                    }
                }           
        }
    }
}
