using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            var gems = Console.ReadLine().Split().Select(int.Parse).ToList();

            Commands(gems);

            Console.WriteLine(string.Join(" ", gems));
        }

        private static void Commands(List<int> gems)
        {
            var input = string.Empty;
            var exclusionFilters = new Queue<KeyValuePair<string, int>>();

            while ((input = Console.ReadLine()) != "Forge")
            {
                var inputArgs = input.Split(';');
                var command = inputArgs[0];
                var filterType = inputArgs[1];
                var filterParameters = int.Parse(inputArgs[2]);

                switch (command)
                {
                    case "Exclude":
                        exclusionFilters.Enqueue(new KeyValuePair<string, int>(filterType, filterParameters));
                        break;
                    case "Reverse":
                        if (exclusionFilters.Count > 0)
                        {
                            exclusionFilters.Dequeue();
                        }
                        break;
                }
            }
            ExecuteExclusions(gems, exclusionFilters);
        }

        private static void ExecuteExclusions(List<int> gems, Queue<KeyValuePair<string, int>> exclusionFilter)
        {
            foreach (var filter in exclusionFilter.Reverse())
            {
                switch (filter.Key)
                {
                    case "Sum Left":
                        FilterLeft(filter.Value, gems);
                        break;
                    case "Sum Right":
                        FilterRight(filter.Value, gems);
                        break;
                    case "Sum Left Right":
                        FilterLeftRight(filter.Value, gems);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void FilterLeftRight(int value, List<int> gems)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                var leftGemPower = (i == 0) ? 0 : gems[i - 1];
                var rightGemPower = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (leftGemPower + gems[i] + rightGemPower == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void FilterRight(int value, List<int> gems)
        {
            while (gems.Count > 0 && gems.Last() == value)
            {
                gems.RemoveAt(gems.Count - 1);
            }
            for (int i = 0; i < gems.Count; i++)
            {
                var rightNum = (i == gems.Count - 1) ?0 : gems[i - 1];
                if (gems[i] + rightNum == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void FilterLeft(int value, List<int> gems)
        {
            while (gems.Count > 0 && gems.First() == value)
            {
                gems.RemoveAt(0);
            }
            for (int i = gems.Count - 1; i >= 0; i--)
            {
                var leftNum = (i > 0) ? gems[i - 1] : 0;
                if (gems[i] + leftNum == value)
                {
                    gems.RemoveAt(i);
                }
            }
        }
    }
}
