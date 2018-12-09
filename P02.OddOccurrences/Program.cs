namespace P02.OddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().ToLower().Split().ToArray();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var item in words)
            {
                if (!counts.ContainsKey(item))
                {
                    counts.Add(item, 0);
                }
                counts[item] += 1;
            }

            foreach (var item in counts)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + ' ');
                }
            }
            Console.WriteLine();
        }
    }
}