namespace P04.IronGirder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, int> townTime = new Dictionary<string, int>();
            Dictionary<string, int> townPassengers = new Dictionary<string, int>();

            while (command != "Slide rule")
            {
                string[] input = command.Split(':').ToArray();
                string townName = input[0];
                string timePassConcat = input[1];
                string[] timePass = timePassConcat.Split("->").ToArray();
                //string ambush = input[1].Split(':')[0].Trim();

                if (timePass[0] == "ambush")
                {
                    int passengersCount = int.Parse(timePass[1]);
                    if (!townTime.ContainsKey(townName))
                    {
                        townTime.Add(townName, 0);
                        townPassengers.Add(townName, 0);
                    }
                    if (townTime[townName] != 0)
                    {
                        townTime[townName] = 0;
                    }
                    if (townPassengers[townName] != 0)
                    {
                        townPassengers[townName] -= passengersCount;
                    }
                }
                else
                {
                    int time = int.Parse(timePass[0]);
                    int passengersCount = int.Parse(timePass[1]);

                    if (!townTime.ContainsKey(townName))
                    {
                        townTime.Add(townName, time);
                        townPassengers.Add(townName, 0);
                    }
                    if (townTime[townName] == 0)
                    {
                        townTime[townName] = time;
                    }
                    else
                    {
                        townTime[townName] = Math.Min(townTime[townName], time);
                    }
                    townPassengers[townName] += passengersCount;
                }

                command = Console.ReadLine();
            }


            foreach (var town in townTime.OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                var city = townPassengers.Where(x => x.Key == town.Key).FirstOrDefault();
                if (city.Value == 0 || town.Value == 0)
                {

                }
                else
                {
                    Console.WriteLine($"{town.Key} -> Time: {town.Value} -> Passengers: {city.Value}");
                }
            }
        }
    }
}