using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture._04
{
    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split(' ')
                .Where(x => x.Length % 2 == 0)
                .ToList();
            //.ForEach(x => Console.WriteLine(x));

            foreach (var word in list)
            {

            }



        }
    }
}
