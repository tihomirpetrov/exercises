namespace P05.SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> registeredUser = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string command = input[0];
                string username = input[1];

                if (command == "register")
                {
                    string licensePlateNumber = input[2];


                    if (!registeredUser.ContainsKey(username))
                    {
                        registeredUser.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");                        
                    }
                    else if (registeredUser[username].Contains(licensePlateNumber))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    registeredUser[username] = licensePlateNumber;
                }
                else
                {
                    if (!registeredUser.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        registeredUser.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }
            foreach (var item in registeredUser)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}