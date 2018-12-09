namespace P01.CountRealNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Dictionary<double, int> counts = new Dictionary<double, int>();

            foreach (var item in numbers)
            {                
                if (!counts.ContainsKey(item))
                {
                    counts.Add(item, 0);
                }
                    counts[item] += 1;
            }

            foreach (var item in counts.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}