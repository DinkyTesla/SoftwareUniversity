using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._1.CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double currency = double.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();

            double result = 0;

            //double BGN = 1;
            double USD = 1.79549;
            double EUR = 1.95583;
            double GBP = 2.53405;
            
            if (inputCurrency == "BGN")
            {
                result = currency;
            }
            else if(inputCurrency == "USD")
            {
                result = currency * USD;
            }
            else if(inputCurrency == "EUR")
            {
                result = currency * EUR; 
            }
            else if(inputCurrency == "GBP")
            {
                result = currency * GBP;
            }

            if(outputCurrency == "USD")
            {
                result = result / USD;
            }
            else if(outputCurrency == "EUR")
            {
                result = result / EUR;
            }
            else if (outputCurrency == "GBP")
            {
                result = result / GBP;
            }

            Console.WriteLine("{0} {1}", Math.Round(result, 2), outputCurrency);
        }
    }
}
