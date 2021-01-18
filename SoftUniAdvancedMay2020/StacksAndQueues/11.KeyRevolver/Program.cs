using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfGun = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            long value = long.Parse(Console.ReadLine());

            Queue<int> locksQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);

            Queue<int> bulletsInGun = Reloading(bulletsStack, sizeOfGun);

            int shotBulletsCount = 0;

            while (locksQueue.Count>0 && bulletsStack.Count>=0)
            {
                int currentBullet = 0;
                if (bulletsInGun.Count>0)
                {
                    currentBullet = bulletsInGun.Dequeue();
                    shotBulletsCount++;
                }
                else
                {
                    break;
                }
                
                int currentLock = locksQueue.Peek();

                if (currentBullet<=currentLock)
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsInGun.Count==0 && bulletsStack.Any())
                {
                    bulletsInGun = Reloading(bulletsStack, sizeOfGun);
                    Console.WriteLine("Reloading!");
                }
            }

            long finalBulletPrice = (long)(shotBulletsCount * bulletPrice);
            long money = value - finalBulletPrice;

            if (bulletsStack.Count==0 && locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"{bulletsStack.Count+bulletsInGun.Count} bullets left. Earned ${money}");
            }


        }

        static Queue<int> Reloading(Stack<int> bulletsStack,int sizeOfGun)
        {
            Queue<int> bulletsInGun = new Queue<int>(sizeOfGun);
            int counter = 0;
            while (bulletsStack.Count>0)
            {
                bulletsInGun.Enqueue(bulletsStack.Pop());
                counter++;

                if (counter==sizeOfGun)
                {
                    break;
                }
            }

            return bulletsInGun;

        }
    }
}
