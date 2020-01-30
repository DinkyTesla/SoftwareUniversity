using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _14.TimeForParty
{
class Program
{
    static void Main(string[] args)
    {

        string date = Console.ReadLine();

        DateTime currentDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
             
        if (currentDate.DayOfWeek == DayOfWeek.Friday || currentDate.DayOfWeek == DayOfWeek.Saturday) 
        { 
            Console.WriteLine("Party night! Today is: {0}", currentDate.DayOfWeek.ToString());
        } 
        else
        {
            Console.WriteLine("No party tonight! Today is: {0}", currentDate.DayOfWeek.ToString());
        }
        
            
    }
}
}
