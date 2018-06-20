using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "../Resourse/copyMe.png";
            using (var reader = new FileStream(file,FileMode.Open))
            {
                using (var writer = new FileStream("image.png",FileMode.Create))
                {
                    byte[] buffer = new Byte[4096];
                    
                    while (true)
                    {
                        var readByByte = reader.Read(buffer, 0, buffer.Length);
                        if (readByByte == 0)
                        {
                            break;
                        }
                        writer.Write(buffer,0,buffer.Length);
                    }

                }
            }
        }
    }
}
