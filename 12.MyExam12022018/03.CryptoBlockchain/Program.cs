using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var numOfRows = int.Parse(Console.ReadLine());
            var unitText = new StringBuilder();
            for (int i = 0; i < numOfRows; i++)
            {
                unitText.Append(Console.ReadLine());
            }
            //var pattern = @"((?<brack>{)|\[)((.*?)(?<numbers>[0-9{3|6|9|12|15|18}]+)).*?(?(brack)}|\])";
            var pattern = @"((?<brack>{)|\[)[^\[|{]*?((?<numbers>[0-9{3|6|9|12|15|18}]+))[^\]|}]*?(?(brack)}|\])";
            var matches = Regex.Matches(unitText.ToString(), pattern);
            var resultBuilder = new StringBuilder();
            if (matches.Count != 0)
            {
                foreach (Match match in matches)
                {
                    var lenght = match.Length;
                    var nums = match.Groups["numbers"].Value;

                    for (int i = 0; i < nums.Length; i += 3)
                    {
                        var nnnnn = nums.Substring(i, 3);
                        var num = nums[i].ToString() + nums[i + 1].ToString() + nums[i + 2].ToString();
                        int matchNum = int.Parse(nnnnn) - lenght;
                        resultBuilder.Append((char)matchNum);
                    }
                }

                Console.WriteLine(resultBuilder.ToString().TrimEnd());
            }

        }
    }
}
