namespace P01.Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, string> contestPassword = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userContestPoints = new Dictionary<string, Dictionary<string, int>>();

            while (input != "end of contests")
            {
                string[] tokens = input.Split(':').ToArray();
                string contest = tokens[0];
                string password = tokens[1];

                if (!contestPassword.ContainsKey(contest))
                {
                    contestPassword.Add(contest, password);
                }
                input = Console.ReadLine();
            }

            string input2 = Console.ReadLine();

            while (input2 != "end of submissions")
            {
                string[] tokens = input2.Split("=>").ToArray();
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contestPassword.ContainsKey(contest) && contestPassword.ContainsValue(password))
                {
                    if (!userContestPoints.ContainsKey(username))
                    {
                        userContestPoints.Add(username, new Dictionary<string, int>());
                        userContestPoints[username].Add(contest, points);
                    }
                    else if(userContestPoints.ContainsKey(username))
                    {
                        if (!userContestPoints[username].ContainsKey(contest))
                        {
                            userContestPoints[username].Add(contest, points);
                        }
                        points = Math.Max(userContestPoints[username][contest], points);
                        userContestPoints[username][contest]= points;
                    }
                }
                input2 = Console.ReadLine();
            }

            var userContestPointsFiltered = userContestPoints.OrderByDescending(x => x.Value.Values.Sum()).Take(1);
            string bestCandidate = string.Empty;
            int bestPoints = 0;

            foreach (var candidate in userContestPointsFiltered)
            {
                bestCandidate = candidate.Key;
                foreach (var item in candidate.Value)
                {
                    bestPoints += item.Value;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in userContestPoints.OrderBy(x=>x.Key))
            {                
                Console.WriteLine($"{user.Key} ");
                foreach (var contest in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}