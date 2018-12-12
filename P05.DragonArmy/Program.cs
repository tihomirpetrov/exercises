namespace P05.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<int>>> colorNameStats = new Dictionary<string, Dictionary<string, List<int>>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split().ToArray();
                string color = tokens[0];
                string name = tokens[1];

                if (tokens[2] == "null")
                {
                    tokens[2] = "45";
                }
                if (tokens[3] == "null")
                {
                    tokens[3] = "250";
                }
                if (tokens[4] == "null")
                {
                    tokens[4] = "10";
                }

                int damage = int.Parse(tokens[2]);
                int health = int.Parse(tokens[3]);
                int armor = int.Parse(tokens[4]);

                if (!colorNameStats.ContainsKey(color))
                {
                    colorNameStats.Add(color, new Dictionary<string, List<int>>());
                }
                if (!colorNameStats[color].ContainsKey(name))
                {
                    colorNameStats[color].Add(name, new List<int>());
                }
                if (colorNameStats[color][name].Count > 0)
                {
                    colorNameStats[color][name].RemoveRange(0, 3);
                }
                colorNameStats[color][name].Add(damage);
                colorNameStats[color][name].Add(health);
                colorNameStats[color][name].Add(armor);

            }

            foreach (var color in colorNameStats)
            {
                List<double> stats = new List<double> { 0, 0, 0 };
                int counter = 0;
                foreach (var name in color.Value.OrderBy(x => x.Key))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        stats[i] += name.Value[i];
                    }
                    counter++;
                }
                Console.WriteLine($"{color.Key}::({stats[0] / counter:f2}/{stats[1] / counter:f2}/{stats[2] / counter:f2})");

                foreach (var name in color.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{name.Key} -> damage: {name.Value[0]}, health: {name.Value[1]}, armor: {name.Value[2]}");
                }
            }
        }
    }
}