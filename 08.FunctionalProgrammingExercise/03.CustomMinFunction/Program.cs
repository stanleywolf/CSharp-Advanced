using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            //var smal = Console.ReadLine().Split()
            //    .Select(int.Parse)
            //    .Min();
            //Console.WriteLine(smal);
            var numbers = Console.ReadLine().Split()
                .Select(double.Parse)
                .ToArray();

            Func<double[], double> minFunc = GetMin;
            var minNumber = minFunc(numbers);
            Console.WriteLine(minNumber);

        }
        private static double GetMin(double[] numbers)
        {
            var min = double.MaxValue;

            foreach (var num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }
    }
}
