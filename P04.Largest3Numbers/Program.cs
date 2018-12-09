namespace P04.Largest3Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] sortedNumbers = numbers.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < 3; i++)
            {
                if (sortedNumbers.Length >= 3)
                {
                    Console.Write($"{sortedNumbers[i]}" + ' ');
                }
                else
                {
                    Console.Write(string.Join(" ", sortedNumbers));
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}