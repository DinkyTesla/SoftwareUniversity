using System;


namespace _03.GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter two integers: ");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (num1 >= num2)
            {
                Console.WriteLine("Greater number: {0}", num1);
            }
            else
            {
                Console.WriteLine("Greater number: {0}", num2);
            }
        }
    }
}
