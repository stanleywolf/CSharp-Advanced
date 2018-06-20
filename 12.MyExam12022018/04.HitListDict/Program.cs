using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitListDict
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetInfoIndex = int.Parse(Console.ReadLine());
            if (targetInfoIndex > 90 || targetInfoIndex < 25)
            {
                return;
            }
            var players = new Dictionary<string, Dictionary<string, string>>();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "end transmissions")
            {
                var commandArgs = command.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commandArgs.Length < 2)
                {
                    continue;
                }
                FillDict(players, commandArgs);
            }

            var resLine = Console.ReadLine().Split().ToArray();
            var move = resLine[0];
            var name = resLine[1];
            if (move == "Kill")
            {
                foreach (var player in players)
                {
                    if (player.Key == name)
                    {
                        Console.WriteLine($"Info on {player.Key}:");
                        var infoIndex = 0;
                        foreach (var info in players[name].OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"---{info.Key}: {info.Value}");
                            infoIndex += info.Key.Length + info.Value.Length;
                        }
                        Console.WriteLine($"Info index: {infoIndex}");
                        if (infoIndex >= targetInfoIndex)
                        {
                            Console.WriteLine("Proceed");
                        }
                        else
                        {
                            Console.WriteLine($"Need {targetInfoIndex-infoIndex} more info.");
                        }
                    }
                }
            }
        }

        private static void FillDict(Dictionary<string, Dictionary<string, string>> players, string[] commandArgs)
        {
            var playerName = commandArgs[0];
            var tokens = commandArgs[1].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string plIndex = String.Empty;
            string plValue = string.Empty;
            foreach (var token in tokens)
            {
                var subTokens = token.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                plIndex = subTokens[0];
                plValue = subTokens[1];

                if (!players.ContainsKey(playerName))
                {
                    players.Add(playerName, new Dictionary<string, string>());
                }
                if (!players[playerName].ContainsKey(plIndex))
                {
                    players[playerName].Add(plIndex, plValue);
                }
                players[playerName][plIndex] = plValue;
            }
        }
    }
}
