namespace _03._SoftUni_Bar_Income
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var income = 0.0;

            while (true)
            {
                var customerRegex = new Regex(@"[%][A-Z][a-z]+[%]");
                var productRegex = new Regex(@"[<][a-zA-Z]+[>]");// moje da e \W
                var countRegex = new Regex(@"[|][\d]+[|]");
                var priceRegex = new Regex(@"[\d.\d]+[$]");
                var pricetest = @"[\d.\d]+[$]";

                var input = Console.ReadLine();

                if (input.Contains("end of shift"))
                {
                    break;
                }

                if (customerRegex.IsMatch(input) && productRegex.IsMatch(input) && countRegex.IsMatch(input) 
                    && priceRegex.IsMatch(input))
                {
                    var customerName = input.Split("%")[1];
                    string product = input.Split('<','>')[1];
                    int count = int.Parse(input.Split("|")[1]);
                    //var priceInput = input.Split('|', '$');
                    //double price = double.Parse(priceInput[2]);

                    Match testMatch = Regex.Match(input, pricetest);

                    foreach (var item in input)
                    {
                        var wtfAmIDoing = 
                    }

                    //double totalPrice = price * count;

                    //Console.WriteLine($"{customerName}: {product} - {totalPrice:F2} ");
                    //income += totalPrice;
                }
            }

            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}
//    //  [%][A-Z][a-zA-Z]+[%][<][a-zA-Z]+[>][|][\d]+[|][\d.\d]+[$]
// ([%][A-Z][a-z]+[%])([<][a-zA-Z]+[>])([|][\d]+[|])([\d.\d]+[$])
