using System;
using System.Linq;

namespace _02.Common_Elements
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            foreach (var item in secondArray)
            {
                if (firstArray.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}