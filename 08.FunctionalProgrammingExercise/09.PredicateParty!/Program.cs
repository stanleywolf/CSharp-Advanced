using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _09.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var peoples = Console.ReadLine().Split()
                .ToList();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "Party!")
            {
                var commandArgs = command.Split().ToArray();
                var action = commandArgs[0];
                var criteria = commandArgs[1];
                switch (criteria)
                {
                    case "StartsWith":
                        FilterPeoples(action, peoples, n => n.StartsWith(commandArgs[2]));
                        break;
                    case "EndsWith":
                        FilterPeoples(action, peoples, n => n.EndsWith(commandArgs[2]));
                        break;
                    case "Length":
                        FilterPeoples(action, peoples, n => n.Length == int.Parse(commandArgs[2]));
                        break;
                    default:
                        break;
                }
            }
            PrintResult(peoples);
        }

        private static void PrintResult(List<string> peoples)
        {
            if (peoples.Any())
            {
                var names = string.Join(", ", peoples);
                Console.WriteLine($"{names} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void FilterPeoples(string action, List<string> peoples, Func<string, bool> func)
        {
            for (int i = peoples.Count - 1; i >= 0; i--)
            {
                if (func(peoples[i]))
                {
                    switch (action)
                    {
                        case "Remove":
                            peoples.RemoveAt(i);
                            break;
                        case "Double":
                            peoples.Add(peoples[i]);
                            break;
                        default:
                            break;
                    }                   
                }

            }
        }
    }
}
    

