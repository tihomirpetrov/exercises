namespace P02.AMinerTask
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, int> resourceQuantity = new Dictionary<string, int>();
            string resource = string.Empty;
            int quantity = 0;
            int counter = 0;

            while (command != "stop")
            {
                if (counter % 2 == 0)
                {
                    resource = command;
                    if (!resourceQuantity.ContainsKey(resource))
                    {
                        resourceQuantity.Add(resource, 0);
                    }
                }
                else
                {
                    quantity = int.Parse(command);                   
                    resourceQuantity[resource] += quantity;
                }
                                             
                counter++;
                command = Console.ReadLine();
            }

            foreach (var item in resourceQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}