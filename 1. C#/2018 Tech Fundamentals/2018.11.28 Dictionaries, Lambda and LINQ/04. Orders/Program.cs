﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();
            Dictionary<string, decimal> productPrice = new Dictionary<string, decimal>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] tokens = input.Split();

                string product = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (productPrice.ContainsKey(product) == false)
                {
                    productQuantity[product] = quantity;
                }
                else
                {
                    productQuantity[product] += quantity;
                }
                productPrice[product] = price;
            }

            foreach (var kvp in productQuantity)
            {
                string product = kvp.Key;
                int quantity = kvp.Value;
                decimal price = productPrice[product];

                decimal result = quantity * price;

                Console.WriteLine($"{product} -> {result:F2}");
            }

        }
    }
}
