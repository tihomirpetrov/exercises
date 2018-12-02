namespace Problem04.MeTubeStatistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, int> meTubeStatistics = new Dictionary<string, int>();
            Dictionary<string, int> meTubeLikes = new Dictionary<string, int>();

            while (command != "stats time")
            {
                if (command.Contains("-"))
                {
                    string[] input = command.Split('-').ToArray();
                    string videoName = input[0];
                    int views = int.Parse(input[1]);

                    if (!meTubeStatistics.ContainsKey(videoName))
                    {
                        meTubeStatistics.Add(videoName, views);
                        meTubeLikes.Add(videoName, 0);
                    }
                    else
                    {
                        meTubeStatistics[videoName] += views;
                    }
                }
                if (command.Contains(":"))
                {
                    string[] input = command.Split(':').ToArray();
                    string rate = input[0];
                    string videoName = input[1];
                   
                    if (meTubeLikes.ContainsKey(videoName))
                    {
                        if (rate == "like")
                        {
                            meTubeLikes[videoName] += 1;
                        }
                        if (rate == "dislike")
                        {
                            meTubeLikes[videoName] -= 1;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            string inputSort = Console.ReadLine();
            if (inputSort == "by likes")
            {
                foreach (var item in meTubeLikes.OrderByDescending(x => x.Value))
                {
                    foreach (var item2 in meTubeStatistics)
                    {
                        if (item.Key == item2.Key)
                        {
                            Console.WriteLine($"{item.Key} - {item2.Value} views - {item.Value} likes");
                        }
                    }
                }
            }

            if (inputSort == "by views")
            {
                foreach (var item in meTubeStatistics.OrderByDescending(x => x.Value))
                {
                    foreach (var item2 in meTubeLikes)
                    {
                        if (item.Key == item2.Key)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value} views - {item2.Value} likes");
                        }
                    }
                }
            }
        }
    }
}