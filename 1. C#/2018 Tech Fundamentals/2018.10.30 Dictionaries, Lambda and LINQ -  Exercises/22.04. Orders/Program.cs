using System;
using System.Linq;
using System.Collections.Generic;


namespace _22._04._Orders
{
    public class Program
    {
        public static void Main()
        {
            var keyMaterials = new Dictionary<string, int>();
            var pricesOfMaterials = new Dictionary<string, double>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                if (input.Contains("buy"))
                {
                    break;
                }

                var product = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (!keyMaterials.ContainsKey(product))
                {
                    keyMaterials.Add(product, 0);
                    pricesOfMaterials.Add(product, 0);
                }
                keyMaterials[product] += quantity;
                pricesOfMaterials[product] = price;

            }

            foreach (var item in pricesOfMaterials)
            {
                double value = item.Value;
                string product = item.Key;

                foreach (var kvp in keyMaterials)
                {
                    string secondProduct = kvp.Key;
                    double secondValue = kvp.Value;

                    if (product == secondProduct)
                    {
                        value *= secondValue;
                    }
                }
                Console.WriteLine($"{product} -> {value:F2}");
            }
        }
    }
}
