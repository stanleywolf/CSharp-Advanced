using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsStream = "../Resourse/words.txt";
            var words = new List<string>();
            using (var reader = new StreamReader(wordsStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }
            var finalWords = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
                finalWords[words[i]] = 0;
            }

            using (var reader = new StreamReader("../Resourse/text.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < words.Count; i++)
                    {

                        if (line.ToLower().Contains(words[i]))
                        {
                            finalWords[words[i]]++;
                        }
                    }
                }
            }
            finalWords = finalWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            using (var writer = new StreamWriter("result.txt"))
            {
                foreach (var word in finalWords)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
