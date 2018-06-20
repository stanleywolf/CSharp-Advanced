using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZippingSlicedFiles
{
    class Program
    {
        private const int bufferSize = 4096;
        
        static void Main(string[] args)
        {
            string sourceFile = "../Resourse/sliceMe.mp4";
            string destination = "";
            int parts = 5;
            Slice(sourceFile, destination, parts);

            Zip(sourceFile,destination,parts);
        }

        private static void Slice(string sourceFile, string destination, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {

                string extantion = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long pieceSize = (long) Math.Ceiling((double) reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPeaceSize = 0;
                    if (destination == string.Empty)
                    {
                        destination = "./";
                    }
                    string currentPart = destination + $"Part-{i}.{extantion}";
                    using (var writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPeaceSize += bufferSize;
                            if (currentPeaceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void Zip(string sourceFile, string destination, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {

                string extantion = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long pieceSize = (long) Math.Ceiling((double) reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPeaceSize = 0;
                    if (destination == string.Empty)
                    {
                        destination = "./";
                    }
                    string currentPart = destination + $"Part-{i}.{extantion}.gz";
                    using (GZipStream writer = new GZipStream(new FileStream(currentPart,FileMode.Create),CompressionLevel.Optimal ))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPeaceSize += bufferSize;
                            if (currentPeaceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
