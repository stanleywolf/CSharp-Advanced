using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string,int> people = new Dictionary<string, int>();
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = input[0];
                var age = int.Parse(input[1]);

                if (!people.ContainsKey(name))
                {
                    people[name] = age;
                   // people.Add(name,age);
                }
            }
            var condition = Console.ReadLine();
            var ages = int.Parse(Console.ReadLine());
            var typePrint = Console.ReadLine();
            var filter = CreateFilter(condition, ages);
            var printer = CreatePrinter(typePrint);

            foreach (var person in people)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
            //people.Where(filter).ToList().ForEach(printer);
        }

        static Func<KeyValuePair<string,int>,bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x.Value < age;
            }
            else
            {
                return x => x.Value >= age;
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default: throw new NotImplementedException();
            }
        }
    }
}
