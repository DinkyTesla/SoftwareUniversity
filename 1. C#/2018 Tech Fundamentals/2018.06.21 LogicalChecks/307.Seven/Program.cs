using System;


namespace _307.Seven
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string message = string.Empty;

            if ( password == "s3cr3t!P@ssw0rd")
            {
                message = "Welcome";
            }
            else
            {
                message = "Wrong Password!";
            }
            Console.WriteLine(message);
        }
    }
}
