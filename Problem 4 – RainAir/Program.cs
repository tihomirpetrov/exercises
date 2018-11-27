namespace Problem4.RainAir
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, List<int>> customerFlights = new Dictionary<string, List<int>>();

            while (input != "I believe I can fly!")
            {
                string[] tokens = input.Split().ToArray();

                string equal = tokens[1];
                if (equal == "=")
                {
                    string customerName = tokens[0];
                    string customer2Name = tokens[2];

                    customerFlights[customerName] = new List<int>();

                    foreach (var flight in customerFlights[customer2Name])
                    {
                        customerFlights[customerName].Add(flight);
                    }
                }
                else
                {
                    string customerName = tokens[0];
                    List<int> flights = new List<int>();

                    //for (int i = 1; i < tokens.Length; i++)
                    //{
                    //    flights.Add(int.Parse(tokens[i]));
                    //}

                    if (!customerFlights.ContainsKey(customerName))
                    {
                        customerFlights.Add(customerName, new List<int>());
                    }

                    for (int i = 1; i < tokens.Length; i++)
                    {
                        customerFlights[customerName].Add(int.Parse(tokens[i]));
                    }

                    //customerFlights[customerName].AddRange(flights);
                }

                input = Console.ReadLine();
            }

            customerFlights = customerFlights
                .OrderByDescending(x => x.Value.Count())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);


            //foreach (var customer in customerFlights.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            //{
            //    Console.Write($"#{customer.Key} ::: ");
            //    int counter = 0;

            //    foreach (var item in customer.Value.OrderBy(x => x))
            //    {
            //        counter++;
            //        if (counter == customer.Value.Count)
            //        {
            //            Console.Write($"{item}");
            //        }
            //        else
            //        {
            //            Console.Write($"{item}, ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            foreach (var customer in customerFlights)
            {
                Console.WriteLine($"#{customer.Key} ::: {string.Join(", ", customer.Value.OrderBy(x => x))}");
            }
        }
    }
}
