namespace P09.ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string commmand = Console.ReadLine();
            Dictionary<string, List<string>> sideUser = new Dictionary<string, List<string>>();

            while (commmand != "Lumpawaroo")
            {
                if (commmand.Contains(" | "))
                {
                    string[] tokens = commmand.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string forceSide = tokens[0].Trim();
                    string forceUser = tokens[1].Trim();

                    bool containsThisUser = false;
                    foreach (var kvp in sideUser)
                    {
                        foreach (var user in kvp.Value)
                        {
                            if (kvp.Value.Contains(forceUser))
                            {
                                containsThisUser = true;
                            }
                        }
                    }

                    if (!containsThisUser)
                    {
                        if (!sideUser.ContainsKey(forceSide))
                        {
                            sideUser.Add(forceSide, new List<string>());
                        }
                        sideUser[forceSide].Add(forceUser);
                    }

                }
                else if (commmand.Contains(" -> "))
                {
                    string[] tokens = commmand.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string forceUser = tokens[0].Trim();
                    string forceSide = tokens[1].Trim();

                    foreach (var userSide in sideUser)
                    {
                        if (userSide.Value.Contains(forceUser))
                        {
                            userSide.Value.Remove(forceUser);
                        }
                    }

                    if (!sideUser.ContainsKey(forceSide))
                    {
                        sideUser.Add(forceSide, new List<string>());
                    }

                    sideUser[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                commmand = Console.ReadLine();
            }


            foreach (var side in sideUser.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var item in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}