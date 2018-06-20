using System;
using System.IO;

namespace _03.WritingTextToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Ебал съм ти п..та майна";
            FileStream stream = null;
            try
            {
                stream = new FileStream("log.txt",FileMode.Create);
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                stream.Write(bytes,0,bytes.Length);
            }
            finally 
            {
               stream.Close();
            }
        }
    }
}
