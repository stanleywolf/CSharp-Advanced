using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandsCount = int.Parse(Console.ReadLine());
            var oldVersions = new Stack<string>();
            oldVersions.Push(String.Empty);
            var text = new StringBuilder();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandInput = Console.ReadLine().Split();
                int command = int.Parse(commandInput[0]);
                switch (command)
                {
                    case 1:
                        oldVersions.Push(text.ToString());
                        text.Append(commandInput[1]);
                        break;
                    case 2:
                        oldVersions.Push(text.ToString());
                        int lenght = int.Parse(commandInput[1]);
                        text.Remove(text.Length - lenght, lenght);
                        break;
                    case 3:
                        int index = int.Parse(commandInput[1]);
                        Console.WriteLine(text[index -1]);
                        break;
                    case 4:
                        text.Clear();
                        text.Append(oldVersions.Pop());
                        break;
                }
            }
        }
    }
}
