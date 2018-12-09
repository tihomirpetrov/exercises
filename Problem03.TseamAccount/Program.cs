namespace Problem03.TseamAccount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            List<string> games = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();

            while (command != "Play!")
            {
                string[] tokens = command.Split().ToArray();
                string gameCommand = tokens[0];
                string gameName = tokens[1];

                if (gameCommand == "Install")
                {
                    if (!games.Contains(gameName))
                    {
                        games.Add(gameName);
                    }
                }

                if (gameCommand == "Uninstall")
                {
                    if (games.Contains(gameName))
                    {
                        games.Remove(gameName);
                    }
                }

                if (gameCommand == "Update")
                {
                    if (games.Contains(gameName))
                    {
                        games.Remove(gameName);
                        games.Insert(games.Count, gameName);
                    }
                }

                if (gameCommand == "Expansion")
                {
                    string[] game = gameName.Split('-').ToArray();
                    if (games.Contains(game[0]))
                    {
                        int index = games.IndexOf(game[0]);
                        games.Insert(index + 1, $"{game[0]}:{game[1]}");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", games));
        }
    }
}