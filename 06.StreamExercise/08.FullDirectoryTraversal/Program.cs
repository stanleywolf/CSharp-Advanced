using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08.FullDirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();

            List<string> directories = GetAllDirectories(directoryPath);

            if (!directories.Any())
            {
                Console.WriteLine("No directories found");
                Environment.Exit(0);
            }
            var filesDict = new Dictionary<string,List<FileInfo>>();
            foreach (var dir in directories)
            {
                GetDirectoryFilesByExtension(dir, filesDict);
            }
            if (!filesDict.Any())
            {
                Console.WriteLine("No files found");
                Environment.Exit(0);
            }
            filesDict = filesDict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            SaveReportToFile(filesDict);


        }

        private static List<string> GetAllDirectories(string directoryPath)
        {
            var allDirectories = new List<string>();

            var directories = Directory.GetDirectories(directoryPath);
            foreach (var dir in directories)
            {
                allDirectories.AddRange(GetAllDirectories(dir));
            }
            allDirectories.Add(directoryPath);
            return allDirectories;
        }

        private static void SaveReportToFile(Dictionary<string, List<FileInfo>> filesDict)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDict)
                {
                    string extension = pair.Key;
                    writer.WriteLine(extension);
                    var fileInfos = pair.Value.OrderByDescending(fi => fi.Length);
                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024;
                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }

        private static void GetDirectoryFilesByExtension(string dir, Dictionary<string, List<FileInfo>> files)
        {
            string[] fullPath = Directory.GetFiles(dir);
            foreach (var file in fullPath)
            {
                var fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                if (!files.ContainsKey(extension))
                {
                    files[extension] = new List<FileInfo>();
                }
                
                files[extension].Add(fileInfo);
            }
           
        }
    }
}
