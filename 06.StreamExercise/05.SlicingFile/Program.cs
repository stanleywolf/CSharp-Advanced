using System;
using System.Collections.Generic;
using System.IO;

namespace _05.SlicingFile
{
    class Program
    {
        private const int bufferSize = 4096;

        static void Main(string[] args)
        {
            string sourceFile = "../Resourse/sliceMe.mp4";
            string destination = "";
            int parts = 5;
            var files = new List<string>()
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Slice(sourceFile, destination, parts);
            Assemble(files, destination);
        }

        private static void Assemble(List<string> files, string destination)
        {
            string extantion = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destination == string.Empty)
            {
                destination = "./";
            }
            if (!destination.EndsWith("/"))
            {
                destination += "/";
            }
            string assembledFile = $"{destination}Assembled.{extantion}";

            using (FileStream wtiter = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            wtiter.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
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
        
    }

}
