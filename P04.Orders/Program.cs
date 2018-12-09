namespace P04.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, Dictionary<double, int>> productsPriceQuantity = new Dictionary<string, Dictionary<double, int>>();

            while (command != "buy")
            {
                string[] tokens = command.Split().ToArray();
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!productsPriceQuantity.ContainsKey(product))
                {
                    productsPriceQuantity.Add(product, new Dictionary<double, int>());
                    productsPriceQuantity[product].Add(price, quantity);
                }
                else if (!productsPriceQuantity[product].ContainsKey(price))
                {
                    var tempQuantity = productsPriceQuantity[product].Values.Sum();
                    productsPriceQuantity.Remove(product);
                    productsPriceQuantity.Add(product, new Dictionary<double, int>());
                    productsPriceQuantity[product].Add(price, quantity + tempQuantity);
                }
                else
                {
                    productsPriceQuantity[product][price] += quantity;
                }

                command = Console.ReadLine();
            }

            foreach (var product in productsPriceQuantity)
            {
                string name = product.Key;
                var kvp = product.Value;

                foreach (var item in kvp)
                {
                    Console.WriteLine($"{product.Key} -> {item.Key * item.Value:f2}");
                }
            }
        }
    }
}