using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolverStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var PriceEachbullet = int.Parse(Console.ReadLine());
            var sizeOfGunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split()
                .Select(int.Parse).Reverse().ToArray();
            var locks = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var valueOfIntelligence = int.Parse(Console.ReadLine());

            var bulletQueue = new Queue<int>();
            foreach (var bullet in bullets)
            {
                bulletQueue.Enqueue(bullet);
            }
            var locksQueue = new Queue<int>();
            foreach (var loc in locks)
            {
                locksQueue.Enqueue(loc);
            }
            int counter = sizeOfGunBarrel;
            int countOfBullet = 0;
            while (true)
            {
                if (counter == 0)
                {
                    Console.WriteLine("Reloading!");
                    counter = sizeOfGunBarrel;
                }
                if (bulletQueue.Dequeue() > locksQueue.Peek())
                {
                    Console.WriteLine("Ping!");
                    countOfBullet++;
                }
                else
                {
                    Console.WriteLine("Bang!");
                    countOfBullet++;
                    locksQueue.Dequeue();
                }

                counter--;
                if (bulletQueue.Count == 0 && locksQueue.Count == 0)
                {
                    if (counter == 0)
                    {
                        
                        
                    }
                    var bulletLeft = bullets.Length - countOfBullet;
                    var moneyLeft = valueOfIntelligence - (countOfBullet * PriceEachbullet);
                    Console.WriteLine($"{bulletLeft} bullets left. Earned ${moneyLeft}");
                    return;
                }
                if (locksQueue.Count == 0)
                {
                  if (counter == 0)
                  {
                      Console.WriteLine("Reloading!");
                      counter = sizeOfGunBarrel;
                  }
                    var bulletLeft = bullets.Length - countOfBullet;
                    var moneyLeft = valueOfIntelligence - (countOfBullet * PriceEachbullet);
                    Console.WriteLine($"{bulletLeft} bullets left. Earned ${moneyLeft}");
                    return;
                }
                if (bulletQueue.Count == 0)
                {
                   
                    var locksLeft = locksQueue.Count;
                    Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
                    return;
                }
                
            }

            Console.WriteLine(string.Join(" ",bulletQueue));
            Console.WriteLine(string.Join(" ",locksQueue));
        }
    }
}
