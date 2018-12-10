namespace P04.SnowWhite2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> hatColorNamePhysics = new Dictionary<string, Dictionary<string, int>>();

            while (command != "Once upon a time")
            {
                string[] tokens = command.Split(new char[] { '<', ':', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                string hatColor = tokens[1];
                int physics = int.Parse(tokens[2]);

                if (!hatColorNamePhysics.ContainsKey(hatColor))
                {
                    hatColorNamePhysics.Add(hatColor, new Dictionary<string, int>());
                }
                if (!hatColorNamePhysics[hatColor].ContainsKey(name))
                {
                    hatColorNamePhysics[hatColor].Add(name, physics);
                }
                if (hatColorNamePhysics[hatColor][name] < physics)
                {
                    hatColorNamePhysics[hatColor][name] = physics;
                }

                command = Console.ReadLine();
            }

            hatColorNamePhysics = hatColorNamePhysics.OrderByDescending(x => x.Value.Values.Sum())
                 .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value)
                 .ToDictionary(y => y.Key, y => y.Value));

            List<Tuple<string, string, int>> sortedDwarfs = new List<Tuple<string, string, int>>();

            foreach (var dwarf in hatColorNamePhysics)
            {
                foreach (var item in dwarf.Value)
                {
                    Tuple<string, string, int> singleDwarf = new Tuple<string, string, int>(dwarf.Key, item.Key, item.Value);
                    sortedDwarfs.Add(singleDwarf);
                }
            }

            sortedDwarfs.OrderByDescending(x => x.Item3)
                        .ToList()
                        .ForEach(x => Console.WriteLine($"({x.Item1}) {x.Item2} <-> {x.Item3}"));
        }
    }
}