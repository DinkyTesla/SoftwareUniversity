
namespace _11._Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();

            int money = int.Parse(Console.ReadLine());

            Stack<int> bulletValue = new Stack<int>(bullets);
            Stack<int> locksValue = new Stack<int>(locks);

            int count = 0;
            int bulletCount = bulletValue.Count;

            while (bulletValue.Any() && locksValue.Any())
            {
                int bullet = bulletValue.Pop();
                int @lock = locksValue.Pop();

                if (bullet > @lock)
                {
                    Console.WriteLine("Ping!");
                    locksValue.Push(@lock);
                }
                else
                {
                    Console.WriteLine("Bang!");
                }

                count++;

                if (count == barrelSize && bulletValue.Any())
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
            }

            //if (bulletValue.Any() || bulletValue.Any() == false && locksValue.Any() == false)
            if (locksValue.Any() == false)
            {
                int moneyLeft = money - (bulletCount - bulletValue.Count) * bulletPrice;
                Console.WriteLine($"{bulletValue.Count} bullets left. Earned ${moneyLeft}");
            }
            else  // if (locksValue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksValue.Count}");
            }

        }
    }
}
