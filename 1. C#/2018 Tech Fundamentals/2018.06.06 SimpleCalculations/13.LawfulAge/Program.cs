using System;

using System.Globalization;

namespace _13.LawfulAge
{
class Program
{
static void Main(string[] args)
{

        string date = Console.ReadLine();
        DateTime currentDate = DateTime.ParseExact(date, "d-M-yyyy", CultureInfo.InvariantCulture);
        int ageToAdd = 18;

        currentDate = currentDate.AddYears(ageToAdd);

        Console.WriteLine(currentDate.ToString("dd-MM-yyyy"));
            

}
}
}
