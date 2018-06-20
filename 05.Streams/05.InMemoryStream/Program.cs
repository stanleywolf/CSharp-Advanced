using System;
using System.IO;
using System.Text;

namespace _05.InMemoryStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "Go Fuck Yourself";
           // var text = "Ебах те"; не може на конзолата
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var stream = new MemoryStream(bytes))
            {
                int oneByte;
                while ((oneByte = stream.ReadByte()) != -1)
                {
                    var character = (char)oneByte;
                    Console.Write(character);
                }
                Console.WriteLine();
            }
        }
    }
}
