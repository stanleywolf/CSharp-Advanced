using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "../Resourse/text.txt";
            using (var reader = new StreamReader(file))
            {
                using (var writer = new StreamWriter("../Resourse/output.txt"))
                {
                    int counter = 1;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {                       
                        writer.WriteLine($"Line{counter}: {line}");
                        counter++;
                    }
                }
            }
        }
    }
}
