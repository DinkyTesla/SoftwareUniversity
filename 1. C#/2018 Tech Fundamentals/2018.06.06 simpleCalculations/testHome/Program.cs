using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter Your First Name: ");

        string firstName = Console.ReadLine();

        Console.WriteLine("Enter Your Last Name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter Your Home Town: ");
        string homeTown = Console.ReadLine();

        Console.WriteLine("Enter Your Age: ");
        int age = int.Parse( Console.ReadLine());

        Console.WriteLine("Hey! So, your name is "+firstName + " " + lastName + ", right? And you are from " + homeTown + ". A "
          + age + " years old .. but wait?"  +" "+ "Male or Female? It doesn't matter." );
    }
}
