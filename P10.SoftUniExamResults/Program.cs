namespace P10.SoftUniExamResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, int> userPoints = new Dictionary<string, int>();
            Dictionary<string, int> languageCounts = new Dictionary<string, int>();


            while (command != "exam finished")
            {
                string[] tokens = command.Split('-').ToArray();

                if (tokens[1] == "banned")
                {
                    string user = tokens[0];

                    if (userPoints.ContainsKey(user))
                    {
                        userPoints.Remove(user);
                    }                    
                }

                else
                {
                    string user = tokens[0];
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (!userPoints.ContainsKey(user))
                    {
                        userPoints.Add(user, points);
                    }
                    else
                    {
                        if (points > userPoints[user])
                        {
                            userPoints[user] = points;
                        }
                    }

                    if (!languageCounts.ContainsKey(language))
                    {
                        languageCounts.Add(language, 0);
                    }
                    languageCounts[language]++;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var user in userPoints.OrderByDescending(x =>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var user in languageCounts.OrderByDescending(x =>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value}");
            }
        }
    }
}