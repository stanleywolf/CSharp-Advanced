using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = new List<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {

                var commands = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var action = commands[0];
                var filter = commands[1];
                var index = commands[2];
                if (action == "Add filter")
                {
                    result.Add(filter + " " + index);
                }
                else if (action == "Remove filter")
                {
                    result.Remove(filter + " " + index);
                }

                
            }

            foreach (var res in result)
            {
                var commands = res.Split(' ');
                var filter = commands[0];
                var index = commands[1];

                if (filter == "Starts")
                {
                    guests = guests.Where(p => !p.StartsWith(index)).ToList();
                }
                else if (filter == "Ends")
                {
                    guests = guests.Where(p => !p.EndsWith(index)).ToList();
                }
                else if (filter == "Length")
                {
                    guests = guests.Where(p => p.Length != int.Parse(index)).ToList();
                }
                else if (filter == "Contains")
                {
                    guests = guests.Where(p => !p.Contains(index)).ToList();
                }
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }
    }      
}
