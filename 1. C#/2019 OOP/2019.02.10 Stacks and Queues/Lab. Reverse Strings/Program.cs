
namespace Lab._Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            for (int i = 0; i < input.Length; i++)
            {
                var item = stack.Pop();
                Console.Write(item);
            }
        }
    }
}
