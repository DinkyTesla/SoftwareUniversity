using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Chars_in_a_String
{
    public class Program
    {
        public static void Main()
        {

            //string givenText = Console.ReadLine()
            //    .Split()
            //    .

            //var someDictionary = new Dictionary<char, int>();

            //var newList = new List<char>();

            //foreach (var item in givenText)
            //{

            //    newList.Add(item);
            //}
            //for (int i = 0; i < givenText.Length; i++)
            //{
            //    newlist.add
            //}


            List<string> givenText = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                

            Console.WriteLine();
        }
    }
}
