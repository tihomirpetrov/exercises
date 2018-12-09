namespace P01.CountCharsInAString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split().ToArray();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            foreach (var item in words)
            {
                foreach (var singleChar in item)
                {
                    if (!charsCount.ContainsKey(singleChar))
                    {
                        charsCount.Add(singleChar, 0);
                    }
                    charsCount[singleChar] += 1;
                }
            }            
           
            foreach (var item in charsCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}